using AspNetCoreHero.Results;
using AutoMapper;
using QueenFisher.Core.Interfaces;
using QueenFisher.Data;
using QueenFisher.Data.DTO;
using QueenFisher.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Core.Services
{
    public class GetMealService : IGetMealService

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMealService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<MealDTO>>> GetAllMeals()
        {
            
          
                var response = await _unitOfWork.MealRepository.GetAllMealsAsync();
                if (response != null) return Result<IEnumerable<MealDTO>>.Success((IEnumerable<MealDTO>)response, "successful");
                return Result<IEnumerable<MealDTO>>.Fail("Error Loading User");
            
        }
    }
}
