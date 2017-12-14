using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookATableWeb.ViewModels
{
    public class ReservationsEditViewModel
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ResraurantId { get; set; }
        [Required]
        public int PeopleCount { get; set; }
        public string Comment { get; set; }
        [Required]
        public DateTime ReservationTime { get; set; }
        public int Id { get; set; }
    }
}