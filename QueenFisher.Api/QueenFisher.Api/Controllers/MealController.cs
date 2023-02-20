using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QueenFisher.Core.Interfaces.IServices;
using QueenFisher.Data.DTO;
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

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMeal(string Id)
        {
            var result = await _mealService.GetMeal(Id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMeal(MealDTO meal)
        {
            var result = await _mealService.AddMealAsync(meal);
            return CreatedAtAction(nameof(GetMeal), new { id = result.Data }, meal);
        }

        [HttpPost("Add-Multiple-Meal")]
        public async Task<IActionResult> AddMultipleMealAsync(MealDTO[] meals)
        {
            var result = await _mealService.AddMultipleMealAsync(meals);
            return Ok(result);
        }

    }
}
