using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.Results;

namespace QueenFisher.Core.Interfaces.IServices
{
    public  interface IMealService
    {
        Task<Result<string>> MealDelete(string mealId);
    }
}
