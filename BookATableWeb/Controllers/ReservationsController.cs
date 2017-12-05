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
    public class ReservationsController : Controller
    {
        // GET: Reservations
        public ActionResult Index()
        {
            ReservationsRepository repository = new ReservationsRepository();
            List<Reservation> reservations = repository.GetAll();
            ReservationsListViewModel model = new ReservationsListViewModel();
            model.Reservation = reservations;
            RestaurantsRepository rep = new RestaurantsRepository();
            List<Restaurant> restaurants = rep.GetAll();
            model.Restaurants = restaurants;
            UsersRepository repo = new UsersRepository();
            List<User> users = repo.GetAll();
            model.Users = users;
            return View(model);
        }


        public ActionResult Create()
        {
            UsersRepository rep = new UsersRepository();
            ViewBag.UserId = new SelectList(rep.GetAll(), "Id", "Name");
            RestaurantsRepository repo = new RestaurantsRepository();
            ViewBag.RestaurantId = new SelectList(repo.GetAll(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(ReservationsCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                Reservation reservation = new Reservation();
                reservation.PeopleCount = model.PeopleCount;
                reservation.ReservationTime = model.ReservationTime;
                reservation.Comment = model.Comment;
                reservation.UserId = model.UserId;
                reservation.RestaurantId = model.ResraurantId;
                ReservationsRepository repository = new ReservationsRepository();
                repository.Insert(reservation);
                return RedirectToAction("Index");
            }
        }



    }
  
}