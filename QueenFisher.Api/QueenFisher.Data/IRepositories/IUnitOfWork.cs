﻿using QueenFisher.Data;
using QueenFisher.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Data
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }

        IGetMealRepository MealRepository { get; }
        Task<int> Save();

        IMealRepository MealRepository1 { get; }
        IUpdateMealDetailRepo UpdateMealDetailRepo { get; } 

    }
}
