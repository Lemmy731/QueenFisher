using QueenFisher.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<AppUserDto>> GetUserAsynce();
        Task<string> DeleteUser(string userId);
    }
}
