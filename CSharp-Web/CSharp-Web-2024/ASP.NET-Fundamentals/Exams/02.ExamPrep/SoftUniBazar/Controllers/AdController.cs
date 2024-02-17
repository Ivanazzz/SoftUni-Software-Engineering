using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Models;
using System.Globalization;
using System.Security.Claims;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private readonly BazarDbContext data;

        public AdController(BazarDbContext context)
        {
            data = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var ads = await data.Ads
                .AsNoTracking()
                .Select(a => new AdInfoViewModel(
                    a.Id,
                    a.Name,
                    a.Description,
                    a.Price,
                    a.Owner.UserName,
                    a.ImageUrl,
                    a.CreatedOn,
                    a.Category.Name
                    ))
                .ToListAsync();

            return View(ads);
        }

        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            string userId = GetUserId();

            var ads = await data.AdBuyers
                .Where(ab => ab.BuyerId == userId)
                .AsNoTracking()
                .Select(ab => new AdInfoViewModel(
                    ab.AdId,
                    ab.Ad.Name,
                    ab.Ad.Description,
                    ab.Ad.Price,
                    ab.Ad.Owner.UserName,
                    ab.Ad.ImageUrl,
                    ab.Ad.CreatedOn,
                    ab.Ad.Category.Name
                    ))
                .ToListAsync();

            return View(ads);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AdFormViewModel();
            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            var entity = new Ad()
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                OwnerId = GetUserId(),
                ImageUrl = model.ImageUrl,
                CreatedOn = DateTime.Now,
                CategoryId = model.CategoryId
            };

            await data.Ads.AddAsync(entity);
            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var ad = await data.Ads
                .FindAsync(id);

            if (ad == null)
            {
                return BadRequest();
            }

            if (ad.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            var model = new AdFormViewModel()
            {
                Name = ad.Name,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price,
                CategoryId = ad.CategoryId
            };

            model.Categories = await GetCategories();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdFormViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            var ad = await data.Ads
                .FindAsync(id);

            if (ad == null)
            {
                return BadRequest();
            }

            if (ad.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                model.Categories = await GetCategories();

                return View(model);
            }

            ad.Name = model.Name;
            ad.Description = model.Description;
            ad.ImageUrl = model.ImageUrl;
            ad.Price = model.Price;
            ad.CategoryId = model.CategoryId;

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var ad = await data.Ads
                .Include(a => a.AdBuyers)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (ad == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!ad.AdBuyers.Any(ab => ab.BuyerId == userId))
            {
                ad.AdBuyers.Add(new AdBuyer()
                {
                    AdId = ad.Id,
                    BuyerId = userId
                });

                await data.SaveChangesAsync();

                return RedirectToAction(nameof(Cart));
            }

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var ad = await data.Ads
                .Include(a => a.AdBuyers)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();

            if (ad == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var adBuyer = ad.AdBuyers
                .FirstOrDefault(ab => ab.BuyerId == userId);

            if (adBuyer == null)
            {
                return BadRequest();
            }

            ad.AdBuyers.Remove(adBuyer);

            await data.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<IEnumerable<CategoryViewModel>> GetCategories()
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
