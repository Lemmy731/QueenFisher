using QueenFisher.Data.Enums;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Data.DTO
{
    public class MealDTO
    {
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public string TimeTableId { get; set; }

    }
}
