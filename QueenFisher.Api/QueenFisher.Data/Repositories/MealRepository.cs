using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using Microsoft.EntityFrameworkCore;
using QueenFisher.Data.Context;
using QueenFisher.Data.Domains;
using QueenFisher.Data.DTO;
using QueenFisher.Data.IRepositories;

namespace QueenFisher.Data.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly QueenFisherDbContext _context;
        public MealRepository(QueenFisherDbContext context)
        {
            _context = context;
        }

        public async  Task MealDelete(string mealId)
        {
            var result = await _context.Meals.FirstOrDefaultAsync(x => x.Id == mealId);
            if(result != null)
            {
                _context.Meals.Remove(result);
                //await _context.SaveChangesAsync();
            }
            
        }

        public async Task<MealDTO> GetMeal(string Id)
        {
            var meal = await _context.Meals.FindAsync(Id);

            if (meal == null)
            {
                return null;
            }

            var mealDTO = new MealDTO()
            {
                Name = meal.Name,
                TimeTableId = meal.TimeTableId,
            };

            return mealDTO;
        }

        public async Task<string> AddMealAsync(MealDTO meal)
        {
            var newMeal = new Meal()
            {
                Name = meal.Name,
                TimeTableId = meal.TimeTableId,
            };
            var result = await _context.AddAsync(newMeal);
            await _context.SaveChangesAsync();

            return newMeal.Id;
        }

        public async Task AddMultipleMealAsync(MealDTO[] meals)
        {
            if (meals == null)
            {
                return;
            }

            var mealList = new List<Meal>();

            foreach (var meal in meals)
            {
                var newMeal = new Meal()
                {
                    Name = meal.Name,
                    TimeTableId = meal.TimeTableId,
                };

                mealList.Add(newMeal);
            }

            await _context.AddRangeAsync(mealList);
            await _context.SaveChangesAsync();

        }
    }
}
