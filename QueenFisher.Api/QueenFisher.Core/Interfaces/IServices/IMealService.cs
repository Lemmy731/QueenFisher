using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using QueenFisher.Data.DTO;

namespace QueenFisher.Core.Interfaces.IServices
{
    public  interface IMealService
    {
        Task<Result<string>> MealDelete(string mealId);
        Task<Result<MealDTO>> GetMeal(string Id);
        Task<Result<string>> AddMealAsync(MealDTO meal);
        Task<Result<string>> AddMultipleMealAsync(MealDTO[] meals);

    }
}
