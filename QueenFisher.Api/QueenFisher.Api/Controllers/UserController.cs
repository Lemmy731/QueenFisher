using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using QueenFisher.Data;
using QueenFisher.Data.DTO;
using QueenFisher.Data.Enums;
using System.Security.Claims;

namespace QueenFisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("All-User")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUser(string? Role)
        {
            var result = await _userService.GetAllUser(Role);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        
        
        [HttpDelete("Single-User")]
        [Authorize(Roles = "SuperAdmin, Admin, Customer")]
        public async Task<IActionResult> DeleteSingleUser(string userIdToDelete)
        {
            var currentUserIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (currentUserIdClaim == null) return Ok("No User Logged In");
            var currentUserId = currentUserIdClaim.Value;
            var result = await _userService.DeleteUser(currentUserId,userIdToDelete);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Single-User{userId}")]
        [Authorize(Roles = "SuperAdmin,Admin,Customer")]
        public async Task<IActionResult> UpdateUser(string userId, AppUserDtoForUpdate userDto)
        {
            var currentUserIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (currentUserIdClaim == null) return Ok("No User Logged In");
            var currentUserId = currentUserIdClaim.Value;
            var result = await _userService.UpdateUserDetails( currentUserId,userId,userDto);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }

    }
}
