using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Entities;

namespace HouseRentingSystem.Services
{
    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext data;

        public AgentService(HouseRentingDbContext _data)
        {
            this.data = _data;
        }

        public bool AgentExists(string userId) => this.data.Agents.Any(a => a.UserId == userId);

        public void Create(string userId, string phoneNumber)
        {
            var agent = new Agent { UserId = userId, PhoneNumber = phoneNumber };

            this.data.Agents.Add(agent);
            this.data.SaveChanges();
        }

        public int getAgentId(string userId) =>
            this.data.Agents.FirstOrDefault(a => a.UserId == userId)?.Id ?? 0;

        public bool UserHasRents(string userId) => this.data.Houses.Any(h => h.RenterId == userId);

        public bool UserWithPhoneNumberExists(string phoneNumber) =>
            this.data.Agents.Any(a => a.PhoneNumber == phoneNumber);
    }
}
