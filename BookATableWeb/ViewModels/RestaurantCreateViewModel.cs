using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace BookATableWeb.ViewModels
{
    public class RestaurantCreateViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Please insert a valid name.")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5, ErrorMessage ="Please insert a valid address.")]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression("^[1-9][0-9]+$", ErrorMessage = "Please insert visitors between 1-99.")]
        public int Capacity { get; set; }
        [Required]
        public DateTime OpenHour {get;set;}
        [Required]
        public DateTime CloseHour { get; set; }
        public int ManagerId { get; set; }
    }
}