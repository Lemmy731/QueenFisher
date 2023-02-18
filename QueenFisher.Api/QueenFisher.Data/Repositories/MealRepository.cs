using Microsoft.EntityFrameworkCore;
using QueenFisher.Core.Interfaces;
using QueenFisher.Data.Context;
using QueenFisher.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Data.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly QueenFisherDbContext _context;

        public MealRepository(QueenFisherDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<MealsDTO>> GetAllMealsAsync()
        {
            var meals = _context.Meals;
            var result = await meals.Select(x => new MealsDTO
            {
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                IsDeleted = x.IsDeleted,
               
            }).ToListAsync();

            if (result.Count != 0) 
                return result;
            return null;
        }
    }
}
