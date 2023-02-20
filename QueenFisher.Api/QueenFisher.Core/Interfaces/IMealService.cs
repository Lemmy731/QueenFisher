using AspNetCoreHero.Results;
using AspNetCoreHero.Results;
using QueenFisher.Data.DTO;

namespace QueenFisher.Data
{
    public interface IMealService
    {
        Task<Result<IEnumerable<MealDTO>>> GetAllMeals();
    }
}
