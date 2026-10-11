using System.Diagnostics;
using HouseRentingSystem.Models;
using HouseRentingSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace HouseRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHouseService houseService;

        public HomeController(IHouseService _houseService)
        {
            houseService = _houseService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var houses = await houseService.LastThreeHouses();
            return View(houses);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                }
            );
        }
    }
}
