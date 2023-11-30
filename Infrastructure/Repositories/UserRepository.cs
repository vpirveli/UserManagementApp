using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{

    private readonly UserDbContext _userDbContext;
    public UserRepository(UserDbContext userDbContext)
    {
        _userDbContext = userDbContext;
    }

    public async Task CreateUserAsync(User user)
    {
        await _userDbContext.Users.AddAsync(user);
        await _userDbContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(User user)
    {

         _userDbContext.Remove(user);
        await _userDbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userDbContext.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _userDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateUserAsync(User user)
    {
        _userDbContext.Users.Update(user);
        await _userDbContext.SaveChangesAsync();
    }
}
