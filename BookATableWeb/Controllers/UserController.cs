using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Entities;
using DataAccess.Repositories;
using BookATableWeb.ViewModels;

namespace BookATableWeb.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            UsersRepository rep = new UsersRepository();
            //
            
            UsersListViewModel model = new UsersListViewModel();
            model.users = rep.GetAll();

            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UsersCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = new User();
            user.Name = model.Name;
            user.Email = model.Email;
            user.Phone = model.Phone;
            user.Password = model.Password;
            UsersRepository repository = new UsersRepository();
            repository.Insert(user);
            return RedirectToAction("Index");
        }
    }
}