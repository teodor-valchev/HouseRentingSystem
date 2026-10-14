using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Entities;
using HouseRentingSystem.Services.Houses.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Services
{
    public class HouseService : IHouseService
    {
        private readonly HouseRentingDbContext data;

        public HouseService(HouseRentingDbContext _data)
        {
            data = _data;
        }

        public async Task<IEnumerable<HouseCategoryServiceModel>> AllCategories() =>
            await data
                .Categories.Select(c => new HouseCategoryServiceModel { Id = c.Id, Name = c.Name })
                .ToListAsync();

        public bool CategoryExists(int categoryId) => data.Categories.Any(c => c.Id == categoryId);

        public async Task<int> Create(
            string title,
            string address,
            string description,
            string imageUrl,
            decimal pricePerMonth,
            int categoryId,
            int agentId
        )
        {
            var house = new House
            {
                Title = title,
                Address = address,
                Description = description,
                ImageUrl = imageUrl,
                PricePerMonth = pricePerMonth,
                CategoryId = categoryId,
                AgentId = agentId,
            };

            data.Houses.Add(house);
            await data.SaveChangesAsync();

            return house.Id;
        }

        public async Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses() =>
            await data
                .Houses.OrderByDescending(h => h.Id)
                .Select(h => new HouseIndexServiceModel
                {
                    Id = h.Id,
                    Title = h.Title,
                    ImageUrl = h.ImageUrl,
                })
                .Take(3)
                .ToListAsync();
    }
}
