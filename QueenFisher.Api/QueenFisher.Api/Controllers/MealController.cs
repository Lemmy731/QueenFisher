using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueenFisher.Core.Interfaces.IServices;
using QueenFisher.Data.Enums;

namespace QueenFisher.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;
        public MealController(IMealService mealService )
        {
            _mealService = mealService;
        }
        [HttpDelete("Single-Meal")]
        //[Authorize(Roles = "SuperAdmin, Admin, Customer")]
        public async Task<IActionResult> DeleteSingleMeal(string meal_id)
        {
            return Ok(await _mealService.MealDelete (meal_id));
          
        }
    }
}
