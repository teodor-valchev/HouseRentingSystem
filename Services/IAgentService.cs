namespace HouseRentingSystem.Services
{
    public interface IAgentService
    {
        bool AgentExists(string userId);

        bool UserWithPhoneNumberExists(string phoneNumber);

        bool UserHasRents(string userId);

        void Create(string userId, string phoneNumber);

        int getAgentId(string userId);
    }
}
