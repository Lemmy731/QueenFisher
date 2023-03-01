﻿using QueenFisher.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Core.Interfaces
{
    public interface IUpdateMealDetailService
    {
        Task <string> UpdateAsync(UpdateMealDetailDTO updateMeal);

    }
}
