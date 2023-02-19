using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueenFisher.Core.Interfaces;
using QueenFisher.Core.Services;

namespace QueenFisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }


        [HttpGet("All-Meals")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AllMeals()
        {
            var result = await _mealService.GetMeals();
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
