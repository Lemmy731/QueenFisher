using QueenFisher.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Data.IRepositories
{
    public interface IGetMealRepository
    {
        Task<IEnumerable<MealDTO>> GetAllMealsAsync();
    }
}
