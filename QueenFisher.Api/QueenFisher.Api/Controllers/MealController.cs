using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueenFisher.Core.DTO;
using QueenFisher.Core.Interfaces;
using QueenFisher.Core.Services;

namespace QueenFisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IUpdateMealDetailService _userService;

        public MealController(IUpdateMealDetailService userService)
        {
            _userService = userService;
        }

        [HttpPut("UpdateMeal")]
        public async Task<IActionResult> UpdateAsync( UpdateMealDetailDTO updateMeal)
        {
            var result = await _userService.UpdateAsync(updateMeal);

            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
