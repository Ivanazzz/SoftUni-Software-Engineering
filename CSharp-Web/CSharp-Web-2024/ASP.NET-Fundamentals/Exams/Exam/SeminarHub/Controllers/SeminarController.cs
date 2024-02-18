using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SeminarHub.Data;
using SeminarHub.Models;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using static SeminarHub.Data.DataConstants;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext data;

        public SeminarController(SeminarHubDbContext context)
        {
            data = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var events = await data.Seminars
                .AsNoTracking()
                .Select(s => new SeminarInfoViewModel(
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.Details,
                    s.Organizer.UserName,
                    s.DateAndTime,
                    s.Duration,
                    s.Category.Name
                    ))
                .ToListAsync();

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SeminarFormViewModel();
            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarFormViewModel model)
        {
            DateTime dateAndTime = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.DateAndTime,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            int duration;

            if (!int.TryParse(model.Duration, out duration) 
                || duration < SeminarDurationMinimumValue
                || duration > SeminarDurationMaximumValue)
            {
                ModelState
                    .AddModelError(nameof(model.Duration), $"Duration must be a number between {SeminarDurationMinimumValue} and {SeminarDurationMaximumValue}.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            var entity = new Seminar()
            {
                Topic = model.Topic,
                Lecturer = model.Lecturer,
                Details = model.Details,
                OrganizerId = GetUserId(),
                DateAndTime = dateAndTime,
                Duration = duration,
                CategoryId = model.CategoryId
            };

            await data.Seminars.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var seminar = await data.Seminars
                .FindAsync(id);

            if (seminar == null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new SeminarFormViewModel()
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Details = seminar.Details,
                DateAndTime = seminar.DateAndTime.ToString(DataConstants.DateFormat, CultureInfo.InvariantCulture),
                Duration = seminar.Duration.ToString(),
                CategoryId = seminar.CategoryId
            };

            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SeminarFormViewModel model, int id)
        {
            var seminar = await data.Seminars
                .FindAsync(id);

            if (seminar == null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime dateAndTime = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.DateAndTime,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out dateAndTime))
            {
                ModelState
                    .AddModelError(nameof(model.DateAndTime), $"Invalid date! Format must be: {DataConstants.DateFormat}");
            }

            int duration;

            if (!int.TryParse(model.Duration, out duration)
                || duration < SeminarDurationMinimumValue
                || duration > SeminarDurationMaximumValue)
            {
                ModelState
                    .AddModelError(nameof(model.Duration), $"Duration must be a number between {SeminarDurationMinimumValue} and {SeminarDurationMaximumValue}.");
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            seminar.Topic = model.Topic;
            seminar.Lecturer = model.Lecturer;
            seminar.Details = model.Details;
            seminar.DateAndTime = dateAndTime;
            seminar.Duration = duration;
            seminar.CategoryId = model.CategoryId;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var seminar = await data.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!seminar.SeminarsParticipants.Any(p => p.ParticipantId == userId))
            {
                seminar.SeminarsParticipants.Add(new SeminarParticipant()
                {
                    SeminarId = seminar.Id,
                    ParticipantId = userId
                });

                await data.SaveChangesAsync();

                return RedirectToAction(nameof(Joined));
            }

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            var model = await data.SeminarsParticipants
                .Where(sp => sp.ParticipantId == userId)
                .AsNoTracking()
                .Select(sp => new SeminarInfoViewModel(
                    sp.SeminarId,
                    sp.Seminar.Topic,
                    sp.Seminar.Lecturer,
                    sp.Seminar.Details,
                    sp.Seminar.Organizer.UserName,
                    sp.Seminar.DateAndTime,
                    sp.Seminar.Duration,
                    sp.Seminar.Category.Name
                    ))
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var seminar = await data.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var seminarParticipant = seminar.SeminarsParticipants
                .FirstOrDefault(sp => sp.ParticipantId == userId);

            if (seminarParticipant == null)
            {
                return BadRequest();
            }

            seminar.SeminarsParticipants.Remove(seminarParticipant);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await data.Seminars
                .Where(s => s.Id == id)
                .AsNoTracking()
                .Select(s => new SeminarInfoViewModel(
                    s.Id,
                    s.Topic,
                    s.Lecturer,
                    s.Details,
                    s.Organizer.UserName,
                    s.DateAndTime,
                    s.Duration,
                    s.Category.Name
                    ))
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var seminar = await data.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (seminar.OrganizerId != userId)
            {
                return Unauthorized();
            }

            var model = new SeminarDeleteViewModel(seminar.Id, seminar.Topic, seminar.DateAndTime);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seminar = await data.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (seminar.OrganizerId != userId)
            {
                return Unauthorized();
            }

            data.Seminars.Remove(seminar);
            data.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<IList<CategoryViewModel>> GetCategories()
        {
            return await data.Categories
                .AsNoTracking()
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
    }
}
