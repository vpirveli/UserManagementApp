using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class UserProfileRepository(UserDbContext userDbContext) : IUserProfileRepository
    {
        private readonly UserDbContext _userProfileDbContext = userDbContext;
        public async Task CreateUserAsync(UserProfile userProfile)
        {
            await _userProfileDbContext.UserProfiles.AddAsync(userProfile);
            await _userProfileDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(UserProfile userProfile)
        {
            _userProfileDbContext.UserProfiles.Remove(userProfile);
            await _userProfileDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _userProfileDbContext.UserProfiles.ToListAsync();
        }

        public async Task<UserProfile?> GetByIdAsync(int id)
        {
            return await _userProfileDbContext.UserProfiles.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateUserAsync(UserProfile userProfile)
        {
            _userProfileDbContext.UserProfiles.Update(userProfile);
            await _userProfileDbContext.SaveChangesAsync();
        }
    }
}
