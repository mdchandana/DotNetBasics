using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CleerenCore.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",ErrorMessage ="Password and Confirm Password doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}
