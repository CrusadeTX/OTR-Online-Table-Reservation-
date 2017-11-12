using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Entities;

namespace BookATableWeb.ViewModels
{
    public class UsersListViewModel
    {
      public  List<User> users { get; set; } 
    }
}