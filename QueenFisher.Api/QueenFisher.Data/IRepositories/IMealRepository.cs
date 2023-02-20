using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using QueenFisher.Data.DTO;

namespace QueenFisher.Data.IRepositories
{
    public  interface IMealRepository
    {
        Task MealDelete(string mealId);
        Task<string> AddMealAsync(MealDTO meal);
        Task AddMultipleMealAsync(MealDTO[] meals);
        Task<MealDTO> GetMeal(string Id);
    }
}
