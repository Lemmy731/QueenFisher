using QueenFisher.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueenFisher.Data.DTO
{
    public class AppUserDtoForUpdate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public bool IsActive { get; set; }
        public string? PublicId { get; set; }
        public string UserName { get; set; }
        public string[] Role { get; set; }
        public string Avatar { get; set; }
    }
}
