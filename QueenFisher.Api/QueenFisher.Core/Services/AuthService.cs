using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using QueenFisher.Core.DTO;
using QueenFisher.Core.Interfaces.IRepositories;
using QueenFisher.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthenticationRepository _authrepository;

        public AuthService(IAuthenticationRepository authrepository)
        {
            _authrepository = authrepository;
        }
        public async Task<object> ChangePassword(ChangePasswordDTO model)
        {
            if (model.ConfirmNewPassword != model.NewPassword) return "Password does not match";
            var response = await _authrepository.ChangePassword(model);
            return response;
        }

        public async Task<Response<string>> Confirmemail(string email, string token)
        {
            try
            {
                var response = await _authrepository.Confirmemail(email, token);
                if (response.Succeeded)
                {
                    return Response<string>.Success("email verified successfully", "verification confirmed", (int)HttpStatusCode.Accepted);
                }
                return Response<string>.Fail("email not verified", (int)HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Response<string>.Fail("an error occured while verifying email", (int)HttpStatusCode.InternalServerError);

            }
        }

        public async Task<object> ForgottenPassword(ResetPasswordDTO model)
        {
            var response = await _authrepository.ForgottenPassword(model);
            return response;
        }

        public async Task<Response<string>> Login(LoginDTO model)
        {
            return await _authrepository.Login(model);
        }

        public async Task<Response<string>> RefreshToken()
        {

            return await _authrepository.RefreshToken();
        }

        public async Task<Response<string>> Register(RegisterDTO user)
        {
            var result = await _authrepository.Register(user);
            var response = new Response<string>();
            if (result.Succeeded)
            {
                response.Succeeded = true;
                response.StatusCode = (int)HttpStatusCode.Created;
                response.Message = "Successfully registered";
                response.Data = result.Data;
            }
            else
            {
                response.Succeeded = false;
                response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                response.Message = "Failed to register, please change check the email, username and password.";
            }

            return response;
        }

        public async Task<object> ResetPassword(UpdatePasswordDTO model)
        {
            var response = await _authrepository.ResetPassword(model);
            return response;
        }

        public async Task<Response<string>> ConfirmEmail(string email, string token)
        {
            try
            {
                var response = await _authrepository.Confirmemail(email, token);
                if (response.Succeeded)
                {
                    return Response<string>.Success("email verified successfully", "verification confirmed", (int)HttpStatusCode.Accepted);
                }
                return Response<string>.Fail("email not verified", (int)HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return Response<string>.Fail("an error occured while verifying email", (int)HttpStatusCode.InternalServerError);

            }
        }
    }
}
