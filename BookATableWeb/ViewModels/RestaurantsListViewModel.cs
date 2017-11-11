using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Entities;

namespace BookATableWeb.ViewModels
{
    public class RestaurantsListViewModel
    {
        //public string Address { get; set; }
        public List<Restaurant> Restaurants { get; set; }
    }
}