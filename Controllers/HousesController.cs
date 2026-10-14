using HouseRentingSystem.Infrastructure;
using HouseRentingSystem.Models.Houses;
using HouseRentingSystem.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class HousesController : Controller
    {
        private readonly IHouseService houseService;
        private readonly IAgentService agentService;

        public HousesController(IHouseService _houseService, IAgentService _agentService)
        {
            this.houseService = _houseService;
            this.agentService = _agentService;
        }

        [HttpGet]
        public IActionResult All()
        {
            return View(new AllHousesQueryModel());
        }

        [Authorize]
        public IActionResult Mine()
        {
            return View(new AllHousesQueryModel());
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            return View(new HouseDetailsViewModel());
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (!agentService.AgentExists(User.Id()))
            {
                return RedirectToAction(nameof(AgentController.Become), "Agents");
            }
            var categories = await houseService.AllCategories();

            var model = new HouseFormModel() { Categories = categories };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            if (!agentService.AgentExists(User.Id()))
            {
                return RedirectToAction(nameof(AgentController.Become), "Agents");
            }

            if (!houseService.CategoryExists(model.CategoryId))
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist.");
            }

            if (!ModelState.IsValid)
            {
                var categories = await houseService.AllCategories();

                return View(new HouseFormModel() { Categories = categories });
            }

            var agentId = agentService.getAgentId(User.Id());

            var newHouseId = await houseService.Create(
                model.Title,
                model.Address,
                model.Description,
                model.ImageUrl,
                model.PricePerMonth,
                model.CategoryId,
                agentId: 1
            );

            return RedirectToAction(nameof(Details), new { id = newHouseId });
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            return View(new HouseFormModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, HouseFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            return View();
        }

        [Authorize]
        public IActionResult Delete(HouseDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Rent(int id)
        {
            return RedirectToAction(nameof(Mine));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Leave(int id)
        {
            return RedirectToAction(nameof(Mine));
        }
    }
}
