using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.Results;

namespace QueenFisher.Data.IRepositories
{
    public  interface IMealRepository
    {
        Task MealDelete(string mealId);
    }
}
