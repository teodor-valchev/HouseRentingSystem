using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Models.Agents;
using HouseRentingSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            this.agentService = _agentService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Become()
        {
            var userId = ClaimsPrincipalExtensions.Id(User);
            if (!this.agentService.AgentExists(userId))
            {
                return View();
            }

            return RedirectToAction(nameof(HousesController.All), "Houses");
        }

        [Authorize]
        [HttpPost]
        public IActionResult Become(BecomeAgentFormModel model)
        {
            var userId = ClaimsPrincipalExtensions.Id(User);

            if (agentService.AgentExists(userId))
            {
                return BadRequest();
            }

            if (agentService.UserWithPhoneNumberExists(nameof(model.PhoneNumber)))
            {
                ModelState.AddModelError(nameof(model.PhoneNumber), "Phone number already exists");
            }

            if (agentService.UserHasRents(userId))
            {
                ModelState.AddModelError("Error", "You should have no rents to become agent!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            agentService.Create(userId, model.PhoneNumber);

            return RedirectToAction(nameof(HousesController.All), "Houses");
        }
    }
}
