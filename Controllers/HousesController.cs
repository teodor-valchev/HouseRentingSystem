using HouseRentingSystem.Models.Houses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class HousesController : Controller
    {
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
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(HouseFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = 1 });
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
