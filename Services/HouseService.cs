using HouseRentingSystem.Data;
using HouseRentingSystem.Services.Models;

namespace HouseRentingSystem.Services
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext data;

        public HouseService(HouseRentingDbContext _data)
        {
            data = _data;
        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses() =>
            data
                .Houses.OrderByDescending(h => h.Id)
                .Select(h => new HouseIndexServiceModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl,
                })
                .Take(3)
                .ToList();
    }
}
