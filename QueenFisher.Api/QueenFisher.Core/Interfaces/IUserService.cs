using AspNetCoreHero.Results;

using QueenFisher.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Data
{
    public interface IUserService
    {
        Task<Result<IEnumerable<AppUserDto>>> GetAllUser(string? Role);
        Task<Result<string>> DeleteUser(string currentUserId, string userIdToDelete);
        Task<Result<AppUserDtoForUpdate>> UpdateUserDetails(string currentUser, string userId, AppUserDtoForUpdate userDto);
    }
}
