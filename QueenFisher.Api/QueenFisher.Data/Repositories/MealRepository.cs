using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QueenFisher.Data.Context;
using QueenFisher.Data.Domains;
using QueenFisher.Data.DTO;
using QueenFisher.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Data.Repositories
{
    public class MealRepository : IMealRepository
    {
       
        private QueenFisherDbContext _context;
        
        private IMapper _mapper;

        

        public MealRepository(QueenFisherDbContext context, IMapper mapper)
        {
            _context = context;
            
            _mapper = mapper;
        }

        public async Task<IEnumerable<MealDTO>> GetAllMealsAsync()
        {
            var meals = _context.Meals;
           
           
            
                var res = _mapper.Map<IEnumerable<MealDTO>>(meals.ToList());
                if (res.Any())
                {
                    return res;
                }
                return null;

               

            
            
            
        }
    }
}
