using QueenFisher.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Core.Interfaces.IRepositories
{
    public interface IAuthenticationRepository
    {
        Task<Response<string>> Login(LoginDTO model);
        Task<Response<string>> Register(RegisterDTO user);
        Task<Response<string>> RefreshToken();
        public Task<object> ChangePassword(ChangePasswordDTO changePasswordDTO);
        public Task<object> ResetPassword(UpdatePasswordDTO resetPasswordDTO);
        public Task<object> ForgottenPassword(ResetPasswordDTO model);
        Task<Response<string>> Confirmemail(string email, string token);
    }
}
