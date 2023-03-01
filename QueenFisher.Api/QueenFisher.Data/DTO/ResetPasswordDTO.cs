using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Data.DTO
{
    public class ResetPasswordDTO
    {

        IUserRepository UserRepository { get; }
        //IUpdateMealDetailRepo UpdateMealDetailRepo { get; }

        public string Email { get; set; }

    }
}
