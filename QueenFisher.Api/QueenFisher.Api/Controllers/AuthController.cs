using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueenFisher.Core.DTO;
using QueenFisher.Core.Interfaces.IServices;

namespace QueenFisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO user)
        {
            var register = await _authService.Register(user);
            if (register.Succeeded == true) return Ok(register);
            return BadRequest(register);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var login = await _authService.Login(model);
            if (login.Succeeded == false) return Unauthorized(login);
            return Ok(login);
        }
        [Authorize]
        [HttpGet("Refresh-Token")]
        public async Task<IActionResult> RefreshToken()
        {
            var token = await _authService.RefreshToken();
            if (token.Succeeded == false) return BadRequest(token);
            return Ok(token);
        }
        [HttpPost("Change-Password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDTO model)
        {
            var result = await _authService.ChangePassword(model);
            if (result.ToString().Contains("login")) return Unauthorized(result);
            if (result.ToString().Contains("character")) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("Reset-Password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO model)
        {
            var result = await _authService.ForgottenPassword(model);
            return Ok(result);
        }
        [HttpPost("Reset-Update-Password")]
        public async Task<IActionResult> ResetUpdatePassword([FromBody] UpdatePasswordDTO model, string Token)
        {
            var result = await _authService.ResetPassword(model);
            return Ok(result);
        }
    }
}
