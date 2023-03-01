using Microsoft.EntityFrameworkCore;
using QueenFisher.Core.DTO;
using QueenFisher.Core.Interfaces;
using QueenFisher.Data.Context;
using QueenFisher.Data.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QueenFisher.Data.Repositories
{
    public class UpdateMealDetailRepo: IUpdateMealDetailRepo
    {
        private readonly QueenFisherDbContext _context;

        public UpdateMealDetailRepo(QueenFisherDbContext context)
        {
            _context = context;
        }

        public async Task<string> UpdateAsync(UpdateMealDetailDTO meal)
        {
            var response = await _context.Meals.FirstOrDefaultAsync(x => x.Id == meal.Id);
            if (response != null)
            {
                
                response.Name = meal.Name;
                _context.Meals.Update(response);
                await _context.SaveChangesAsync(); 
                return "updated";
            }
            return "Operation Failed";
        }
    }
}
