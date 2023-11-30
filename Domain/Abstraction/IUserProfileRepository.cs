using Domain.Models;

namespace Domain.Abstraction;

public interface IUserProfileRepository
{
    Task<UserProfile?> GetByIdAsync(int id);
    Task<IEnumerable<UserProfile>> GetAllAsync();
    Task CreateUserAsync(UserProfile userProfile);
    Task UpdateUserAsync(UserProfile userProfile);
    Task DeleteUserAsync(UserProfile userProfile);
}
