using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueenFisher.Core.Services;
using QueenFisher.Data;
using QueenFisher.Data.Enums;

namespace QueenFisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetMealController : ControllerBase
    {
        private readonly IGetMealService _mealService;

        public GetMealController(IGetMealService mealService)
        {
            _mealService = mealService;
        }


        [HttpGet("All-Meals")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetMeals()
        {
            var result = await _mealService.GetAllMeals();
            return result.Succeeded ? Ok(result) : BadRequest(result);
        }
    }
}
