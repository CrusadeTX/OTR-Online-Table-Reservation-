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
    [Authorize(Roles = "Admin")]
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
        public ActionResult Create(UsersEditViewModel model)
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

        public ActionResult Edit(int Id)
        {

            UsersRepository repo = new UsersRepository();
            User dbusers = new User();
            dbusers = repo.Get(Id);
            UsersEditViewModel model = new UsersEditViewModel();
            model.Name = dbusers.Name;
            model.Email = dbusers.Email;
            model.Phone = dbusers.Phone;
            model.Password = dbusers.Password;
            model.Id = Id;
            UsersRepository rep = new UsersRepository();

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(UsersEditViewModel model)
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
            user.Id = model.Id;
            UsersRepository repo = new UsersRepository();
            repo.Update(user);

            return RedirectToAction("Index");

        }

        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(User user)
        {
            UsersRepository rep = new UsersRepository();

            rep.Delete(user);
            return RedirectToAction("Index");
        }
    }
}