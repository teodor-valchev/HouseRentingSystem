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
            return RedirectToAction(nameof(HousesController.All), "Houses");
        }
    }
}
