﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repositories;
using DataAccess.Entities;
using BookATableWeb.ViewModels;

namespace BookATableWeb.Controllers
{
    public class RestaurantsController : Controller
    {
        // GET: Restaurants
        public ActionResult Index()
        {
            RestaurantsRepository repository = new RestaurantsRepository();
            List<Restaurant> restaurants = repository.GetAll();
            RestaurantsListViewModel model = new RestaurantsListViewModel();
            model.Restaurants = restaurants;
            return View(model);
        }

        public ActionResult Create()
        {
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
            RestaurantsRepository repository = new RestaurantsRepository();
            repository.Insert(restaurant);
            return RedirectToAction("Index");
        }

    }
}