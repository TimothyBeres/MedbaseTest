﻿using System.ComponentModel.DataAnnotations;

namespace Sentry1.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Mäleta mind")]
        public bool RememberMe { get; set; }
    }
}
