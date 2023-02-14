using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using QueenFisher.Core;
using QueenFisher.Core.DTO;
using QueenFisher.Core.Interfaces.IRepositories;
using QueenFisher.Core.Interfaces.IServices;
using QueenFisher.Core.Utilities;
using QueenFisher.Data.Domains;
using QueenFisher.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QueenFisher.Data.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _token;
        private readonly ITokenDetails _tokenDetails;
        private readonly IHttpContextAccessor _httpContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;
        public AuthenticationRepository(UserManager<AppUser> userManager, ITokenService token,
           ITokenDetails tokenDetails, IHttpContextAccessor httpContext,
           RoleManager<IdentityRole> roleManager, IEmailService emailService)
        {
            _userManager = userManager;
            _token = token;
            _tokenDetails = tokenDetails;
            _httpContext = httpContext;
            _roleManager = roleManager;
            _emailService = emailService;
        }
        public string GetId() => _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        public async Task<object> ChangePassword(ChangePasswordDTO changePasswordDTO)
        {
            var user = await _userManager.FindByIdAsync(GetId());
            if (user == null) return "Please login to change password";
            var result = await _userManager.ChangePasswordAsync(user, changePasswordDTO.CurrentPassword, changePasswordDTO.NewPassword);
            if (!result.Succeeded) return "Unable to change password: password should contain a Capital, number, character and minimum length of 8";
            return "Password changed succesffully";
        }

        public Task<object> ForgottenPassword(ResetPasswordDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<string>> Login(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            var response = new Response<string>();
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var UserModel = new UserModel
                {
                    Id = user.Id,
                    UserName = model.Username,
                    Role = userRoles.FirstOrDefault() ?? ""
                };


                var refreshToken = _token.SetRefreshToken();
                //var refreshToken = SetRefreshToken();
                await SaveRefreshToken(user, refreshToken);
                response.Succeeded = true;
                response.Data = _token.CreateToken(UserModel);
                response.StatusCode = (int)HttpStatusCode.Accepted;
                response.Message = "Logged in successfully";
            }
            else
            {
                response.Succeeded = false;
                response.Message = "Wrong Credential";

                response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            return response;
        }

        private async Task SaveRefreshToken(AppUser user, RefreshToken refreshToken)
        {
            user.RefreshToken = refreshToken.Refreshtoken;
            user.RefreshTokenExpiryTime = refreshToken.RefreshTokenExpiryTime;
            await _userManager.UpdateAsync(user);
        }

        public async Task<Response<string>> RefreshToken()
        {
            var currentToken = _httpContext.HttpContext.Request.Cookies["refresh-token"];
            var user = await _userManager.FindByIdAsync(_tokenDetails.GetId());

            var response = new Response<string>();
            response.Succeeded = false;
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            if (user == null || user.RefreshToken != currentToken)
            {
                response.Data = "Invalid refresh token";
            }
            else if (user.RefreshTokenExpiryTime < DateTime.Now)
            {
                response.Message = "Token Expired";
            }
            else
            {
                var UserModel = new UserModel
                {
                    Id = _tokenDetails.GetId(),
                    UserName = _tokenDetails.GetUserName(),
                    Role = _tokenDetails.GetRoles()
                };

                response.Succeeded = true;
                response.Data = _token.CreateToken(UserModel);
                response.Message = "Successful refreshed token";
                response.StatusCode = (int)HttpStatusCode.Accepted;

                var refreshToken = _token.SetRefreshToken();
                await SaveRefreshToken(user, refreshToken);
            }
            return response;
        }

        public async Task<Response<string>> Register(RegisterDTO user)
        {
            try
            {
                // checks if a user with the specified email already exists in the system
                var checkUser = await _userManager.FindByEmailAsync(user.Email);
                if(checkUser == null)
                {
                    return Response<string>.Fail("user already exist", (int)HttpStatusCode.Unauthorized);
                }
                //var mapInitializer = new MapInitializer();
                //var newUser = mapInitializer.regMapper.Map<RegisterDTO, AppUser>(user);
                //retrieves a list of roles from the system
               
                var newUser = new AppUser();
                newUser.Email = user.Email;
                newUser.UserName = user.UserName;
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.PhoneNumber = user.Phone;
                newUser.Avatar = user.Avatar;
                //newUser.Gender = user.Gender;
                newUser.PasswordHash = user.Password;
                newUser.PublicId = user.Publicid;
                newUser.IsActive = user.IsActive;
                newUser.Gender = user.Gender;


                var roles = await _roleManager.Roles.ToListAsync();
                //If there are no roles, it creates a new role with the name "User".
                if (roles.Count == 0) await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
                //create a new user in the system
                var result = await _userManager.CreateAsync(newUser, user.Password);
                if (!result.Succeeded)
                {
                    return Response<string>.Fail("user could not be created", (int)HttpStatusCode.UnprocessableEntity);
                }
                //If the user creation is successful, the function adds the new user to the "User"  role
                await _userManager.AddToRoleAsync(newUser, "Customer");
                //generates an email confirmation token
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                return Response<string>.Success($"click the link sent to {user.Email} to confirm your email", token, (int)HttpStatusCode.Created);
            }
            catch (Exception ex)
            {

                return Response<string>.Fail("user could not be created, an error occured", (int)HttpStatusCode.InternalServerError);
            }
           

        }

        public async Task<object> ResetPassword(UpdatePasswordDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return "The Email Provided is not associated with a user account.";
            }
            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);

            if (!result.Succeeded)
            {
                return "The Provided Reset Token is Invalid or Has expired";
            }
            return "Password Reset Successfully";
        }

        public async Task<Response<string>> Confirmemail(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Response<string>.Fail("user does not exist", (int)HttpStatusCode.NotFound);
            }
            var res = await _userManager.ConfirmEmailAsync(user, token);
            if (res.Succeeded)
            {
                return Response<string>.Success("email has been confirmed", "confirmed", (int)HttpStatusCode.Accepted);
            }
            return Response<string>.Fail("an error occured while comfirming email", (int)HttpStatusCode.InternalServerError);
        }
    }
}
