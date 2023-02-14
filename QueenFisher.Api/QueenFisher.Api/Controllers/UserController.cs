using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueenFisher.Core.Interfaces;
using QueenFisher.Data.Enums;

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
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUser()
        {
            var result = await _userService.GetAllUser();
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
        
        
        [HttpDelete("Single-User-{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSingleUser(string Id)
        {
            var result = await _userService.DeleteUser(Id);
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
