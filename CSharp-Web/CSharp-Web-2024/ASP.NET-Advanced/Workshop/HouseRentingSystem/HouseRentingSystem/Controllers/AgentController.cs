using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using HouseRentingSystem.Core.Models.Agent;
using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Extensions;

namespace HouseRentingSystem.Controllers
{
    public class AgentController : BaseController
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }

        [HttpGet]
        public async Task<IActionResult> Become()
        {
            if (await agentService.ExistByIdAsync(User.Id()))
            {
                // if the user is already agent
                return BadRequest();
            }

            var model = new BecomeAgentFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Become(BecomeAgentFormModel model)
        {
            return RedirectToAction(nameof(HouseController.All), "House");
        }
    }
}
