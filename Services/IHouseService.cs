using HouseRentingSystem.Services.Models;

namespace HouseRentingSystem.Services
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseIndexServiceModel>> LastThreeHouses();
    }
}
