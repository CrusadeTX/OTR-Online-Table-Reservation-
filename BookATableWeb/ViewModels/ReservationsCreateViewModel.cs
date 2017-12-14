using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookATableWeb.ViewModels
{
    public class ReservationsCreateViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        
        public int ResraurantId { get; set; }
        [Required]

        [RegularExpression(@"[1-9][0-9]", ErrorMessage = "Please insert a valid count.")]
        public int PeopleCount { get; set; }

        [StringLength(50, ErrorMessage = "Please insert a valid comment.")]
        public string Comment { get; set; }
        [Required]
        public DateTime ReservationTime { get; set; }

    }
}