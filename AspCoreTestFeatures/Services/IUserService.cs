using Newtonsoft.Json;

namespace AspCoreTestFeatures.Services
{
    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
    }
}