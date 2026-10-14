using HouseRentingSystem.Services.Houses.Models;

namespace HouseRentingSystem.Services
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();

        Task<IEnumerable<HouseCategoryServiceModel>> AllCategories();

        bool CategoryExists(int categoryId);

        Task<int> Create(
            string title,
            string address,
            string description,
            string imageUrl,
            decimal pricePerMonth,
            int categoryId,
            int agentId
        );
    }
}
