using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookATableWeb.ViewModels
{
    public class UsersEditViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Please insert a valid username.")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"/^ (?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$/gm", ErrorMessage = "Password must contain 1 uppercase, lowercase and 1 number.")]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public int Id { get; set; }
    }

}
