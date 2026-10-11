using HouseRentingSystem.Data;

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
    }
}
