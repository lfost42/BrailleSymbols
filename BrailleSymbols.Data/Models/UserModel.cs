using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BrailleSymbols.Data.Models
{
    public class UserModel : IdentityUser
    {
        [Display(Name = "First Name"), StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name"), StringLength(50, ErrorMessage = "The {0} must be between {2} and {1} characters long.", MinimumLength = 2)]
        public string LastName { get; set; }

        [NotMapped]
        [Display(Name = "Name")]
        public string FullName => $"{FirstName} {LastName}";

        public byte[] ImageData { get; set; }
        [DataType(DataType.Upload)]
        [NotMapped]
        public IFormFile ImageIform { get; set; }
        public string ContentType { get; set; }
    }
}
