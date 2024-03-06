namespace HouseRentingSystem.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistById(string agentId);
    }
}
