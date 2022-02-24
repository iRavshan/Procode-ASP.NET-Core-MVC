using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Requests
{
    public class UserLoginRequest
    {
        [EmailAddress(ErrorMessage = "Elektron pochta noto'g'ri kiritilgan")]
        [Required(ErrorMessage = "Elektron pochta manzilini kiriting")]
        [Display(Name = "Elektron pochta manzil")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parolni kiriting")]
        [Display(Name = "Parol")]
        public string Password { get; set; }
    }
}
