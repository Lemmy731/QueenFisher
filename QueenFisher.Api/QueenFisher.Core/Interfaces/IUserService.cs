using QueenFisher.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Core.Interfaces
{
    public interface IUserService
    {
        Task<Response<IEnumerable<AppUserDto>>> GetAllUser();
        Task<Response<string>> DeleteUser(string userId);
    }
}
