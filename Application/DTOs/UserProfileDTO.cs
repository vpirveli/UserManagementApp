using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class UserProfileDTO
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string PersonalNumber { get; set; } = null!;
    }
}
