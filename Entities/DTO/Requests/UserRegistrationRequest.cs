using Entities.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Requests
{
    public class UserRegistrationRequest
    {

        [Required(ErrorMessage = "Elektron pochta manzilini kiriting")]
        [EmailAddress(ErrorMessage = "Elektron pochta manzilini ")]
        [Display(Name = "Elektron pochta manzili")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parolni kiriting")]
        [Display(Name = "Parol")]
        public string Password { get; set; }
    }
}
