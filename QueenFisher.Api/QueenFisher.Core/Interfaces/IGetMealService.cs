using AspNetCoreHero.Results;
using AspNetCoreHero.Results;
using QueenFisher.Data.DTO;

namespace QueenFisher.Data
{
    public interface IGetMealService
    {
        Task<Result<IEnumerable<MealDTO>>> GetAllMeals();
    }
}
