using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookATableWeb.ViewModels
{
    public class RestaurantCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Email { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public DateTime OpenHour {get;set;}
        [Required]
        public DateTime CloseHour { get; set; }
        public int ManagerId { get; set; }
    }
}