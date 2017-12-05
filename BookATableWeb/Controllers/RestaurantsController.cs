using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repositories;
using DataAccess.Entities;
using BookATableWeb.ViewModels;

namespace BookATableWeb.Controllers
{
   // [Authorize(Roles = "Admin,Manager,Customer")]
    public class RestaurantsController : Controller
    {
        // GET: Restaurants
        [Authorize(Roles = "Customer,Manager,Admin")]
        public ActionResult Index()
        {
            RestaurantsRepository repository = new RestaurantsRepository();
            List<Restaurant> restaurants = repository.GetAll();
            RestaurantsListViewModel model = new RestaurantsListViewModel();
            model.Restaurants = restaurants;
            return View(model);
        }

        [Authorize(Roles = "Manager,Admin")]
        public ActionResult Create()
        {

            UsersRepository rep = new UsersRepository();
            ViewBag.ManagerId = new SelectList(rep.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(RestaurantCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Restaurant restaurant = new Restaurant();
            restaurant.Name = model.Name;
            restaurant.Address = model.Address;
            restaurant.Email = model.Email;
            restaurant.OpenHour = model.OpenHour;
            restaurant.CloseHour = model.CloseHour;
            restaurant.Phone = model.Phone;
            restaurant.Capacity = model.Capacity;
            restaurant.ManagerId = model.ManagerId;
            RestaurantsRepository repository = new RestaurantsRepository();
            repository.Insert(restaurant);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Manager,Admin")]
        public ActionResult Edit(int Id)
        {

            RestaurantsRepository repo = new RestaurantsRepository();
            Restaurant dbrestaurant = new Restaurant();
            dbrestaurant = repo.Get(Id);
            RestaurantsEditViewModel model = new RestaurantsEditViewModel();
            model.Address = dbrestaurant.Address;
            model.Capacity = dbrestaurant.Capacity;
            model.Email = dbrestaurant.Email;
            model.Name = dbrestaurant.Name;
            model.Phone = dbrestaurant.Phone;
            model.OpenHour = dbrestaurant.OpenHour;
            model.ManagerId = dbrestaurant.ManagerId;
            model.CloseHour = dbrestaurant.CloseHour;
            model.Id = Id;
            UsersRepository rep = new UsersRepository();
            ViewBag.ManagerId = new SelectList(rep.GetAll(), "Id", "Name");
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(RestaurantsEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Restaurant rest = new Restaurant();
            rest.Id = model.Id;
            rest.ManagerId = model.ManagerId;
            rest.Name = model.Name;
            rest.OpenHour = model.OpenHour;
            rest.CloseHour = model.CloseHour;
            rest.Capacity = model.Capacity;
            rest.Email = model.Email;
            rest.Phone = model.Phone;
            rest.Address = model.Address;
            RestaurantsRepository repo = new RestaurantsRepository();
            repo.Update(rest);

            return RedirectToAction("Index");

        }




        [Authorize(Roles = "Manager,Admin")]
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete (Restaurant restaurant)
        {
            RestaurantsRepository rep = new RestaurantsRepository();

            rep.Delete(restaurant);
            return RedirectToAction("Index");
        }
        

    }
}