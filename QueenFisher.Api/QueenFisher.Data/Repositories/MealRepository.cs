using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using Microsoft.EntityFrameworkCore;
using QueenFisher.Data.Context;
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
    }
}
