﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace onsales.Web.Models
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "Anterior password")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The {0} field must contain between {2} and {1} characters.")]
        public string OldPassword { get; set; }

        [Display(Name = "Nuevo password")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The {0} field must contain between {2} and {1} characters.")]
        public string NewPassword { get; set; }

        [Display(Name = "Password Confirmado")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "The {0} field must contain between {2} and {1} characters.")]
        [Compare("NewPassword")]
        public string Confirm { get; set; }
    }

}
