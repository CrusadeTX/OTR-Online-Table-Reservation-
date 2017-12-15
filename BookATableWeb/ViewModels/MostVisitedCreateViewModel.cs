using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookATableWeb.ViewModels
{
    public class MostVisitedCreateViewModel
    {
        public List<Reservation> mostVisitedWeekly { get; set; }
        public List<Reservation> mostVisitedMonthly { get; set; }
        public List<Reservation> mostVisitedYearly { get; set; }
        public List<Restaurant> Restaurants { get; set; }
        public List<User> Users { get; set; }
    }
}