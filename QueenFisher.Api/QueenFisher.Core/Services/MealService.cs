using QueenFisher.Core.Interfaces;
using QueenFisher.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Core.Services
{
    public class MealService : IMealService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MealService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Response<IEnumerable<MealsDTO>>> GetMeals()
        {
            var allMeals = await _unitOfWork.MealRepository.GetAllMealsAsync();

            if(allMeals != null)
            {
                return Response<IEnumerable<MealsDTO>>.Success("Meals loaded successfully", allMeals);
            }

            return Response<IEnumerable<MealsDTO>>.Fail("Error Loading Meals");
        }
    }
}
