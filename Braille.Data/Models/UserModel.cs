using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Braille.Data.Models
{
    public class UserModel : IdentityUser
    {

        [Display(Name = "UserName"), StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string Username { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        [NotMapped]
        public string Token { get; set; }

    }
}
