using Microsoft.AspNetCore.Http;
using NET_Core_Custome_Validations.CustomeValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Core_Custome_Validations.Models
{
    public class Profile
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [CustomeImageValidation]
        public IFormFile ProfileImage { get; set; }
    }
}
