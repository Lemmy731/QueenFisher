using Microsoft.EntityFrameworkCore;
using QueenFisher.Core.Interfaces;
using QueenFisher.Data.Context;
using QueenFisher.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly QueenFisherDbContext _context;

        public UserRepository(QueenFisherDbContext context)
        {
            _context = context;
        }
        public async Task<string> DeleteUser(string userId)
        {
            var response = await _context.Users.FirstOrDefaultAsync(x=>x.Id == userId);
            if(response != null)
            {
                response.IsDeleted = true;
                _context.Users.Update(response);
                return "Deleted";
            }
            return "Operation Failed";
            
        }

        public async Task<IEnumerable<AppUserDto>> GetUserAsynce()
        {
            var users = _context.Users;
            var result = await users.Select(x=> new AppUserDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = (int)x.Gender,
                Avatar = x.Avatar,
                IsActive = x.IsActive,
            }).ToListAsync();
            if(result.Count != 0) return result;
            return null;

        }
    }
}
