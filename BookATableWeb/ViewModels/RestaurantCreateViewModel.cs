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
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Please insert a valid name.")]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"/^\s*(?:\+?(\d{1,3}))?([-. (]*(\d{3})[-. )]*)?((\d{3})[-. ]*(\d{2,4})(?:[-.x ]*(\d+))?)\s*$/gm", ErrorMessage = "Please insert a valid name.")]
        public string Phone { get; set; }
        [Required]
        [RegularExpression(@"/^([A-Z|a-z|0-9](\.|_){0,1})+[A-Z|a-z|0-9]\@([A-Z|a-z|0-9])+((\.){0,1}[A-Z|a-z|0-9]){2}\.[a-z]{2,3}$/gm", ErrorMessage = "Please insert a valid email.")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\- ][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Please insert a valid name.")]
        public int Capacity { get; set; }
        [Required]
        public DateTime OpenHour {get;set;}
        [Required]
        public DateTime CloseHour { get; set; }
        public int ManagerId { get; set; }
    }
}