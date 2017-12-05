using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableWeb.ViewModels
{
    public class ReservationsListViewModel
    {
        public List<Reservation> Reservation { get; set; }
        public List<Restaurant> Restaurants { get; set; }
        public List<User> Users { get; set; }
    }
}