using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.Results;
using MySqlX.XDevAPI.Common;
using QueenFisher.Core.Interfaces.IServices;
using QueenFisher.Data;
using QueenFisher.Data.DTO;
using QueenFisher.Data.IRepositories;

namespace QueenFisher.Core.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MealService(IUnitOfWork unitOfWork, IMealRepository mealRepository)
        {
            _unitOfWork = unitOfWork;
            _mealRepository = mealRepository;
        }
        public async Task<Result<string>> MealDelete(string mealId)
        {
            try
            {
                if (mealId == null)
                {
                    return Result<string>.Fail("Please Enter your Meal_Id");
                }

                await _mealRepository.MealDelete(mealId);
                var result = await _unitOfWork.Save();

                if (result > 0)
                {
                    return Result<string>.Success("Meal Deleted Successfully");
                }
                return Result<string>.Fail("meal not deleted");
            }
            catch (Exception ex)
            {
                return Result<string>.Fail("an error occured while deleting meal");
            }
        }



        public async Task<Result<MealDTO>> GetMeal(string Id)
        {
            try
            {
                var result = await _unitOfWork.MealRepository.GetMeal(Id);
                return Result<MealDTO>.Success(result, "Successful");
            }
            catch (Exception ex)
            {
                //log.Fatal(ex.Message())
                return Result<MealDTO>.Fail("An error occured while getting meal");
            }
        }

        public async Task<Result<string>> AddMealAsync(MealDTO meal)
        {
            try
            {
                var result = await _unitOfWork.MealRepository.AddMealAsync(meal);
                return Result<string>.Success( result, "Meal created successfully");
            }
            catch (Exception ex)
            {
                //log.Fatal(ex.Message())
                return Result<string>.Fail("An error occured while adding meal");
            }

        }


        public async Task<Result<string>> AddMultipleMealAsync(MealDTO[] meals)
        {
            try
            {
                await _unitOfWork.MealRepository.AddMultipleMealAsync(meals);
                return Result<string>.Success("Meals created successfully");
            }
            catch (Exception ex)
            {

                //log.Fatal(ex.Message())
                return Result<string>.Fail("An error occured while adding multipleMeal");
            }
        }



    }
}
