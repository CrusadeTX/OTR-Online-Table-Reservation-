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
    [Authorize(Roles = "Customer,Manager,Admin")]
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
                UsersRepository rep = new UsersRepository();
                ViewBag.UserId = new SelectList(rep.GetAll(), "Id", "Name");
                RestaurantsRepository repo = new RestaurantsRepository();
                ViewBag.RestaurantId = new SelectList(repo.GetAll(), "Id", "Name");
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

        public ActionResult Edit(int Id)
        {

            ReservationsRepository repo = new ReservationsRepository();
            Reservation dbreservation = new Reservation();
            dbreservation = repo.Get(Id);
            ReservationsEditViewModel model = new ReservationsEditViewModel();
            model.PeopleCount = dbreservation.PeopleCount;
            model.ReservationTime = dbreservation.ReservationTime;
            model.Comment = dbreservation.Comment;
            model.UserId = dbreservation.UserId;
            model.ResraurantId = dbreservation.RestaurantId;
            model.Id = Id;
            UsersRepository rep = new UsersRepository();
            ViewBag.UserId = new SelectList(rep.GetAll(), "Id", "Name");
            RestaurantsRepository repository = new RestaurantsRepository();
            ViewBag.RestaurantId = new SelectList(repository.GetAll(), "Id", "Name");
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ReservationsEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                UsersRepository rep = new UsersRepository();
                ViewBag.UserId = new SelectList(rep.GetAll(), "Id", "Name");
                RestaurantsRepository repos = new RestaurantsRepository();
                ViewBag.RestaurantId = new SelectList(repos.GetAll(), "Id", "Name");
                return View();
                
            }
            Reservation reservation = new Reservation();
            reservation.Id = model.Id;
            reservation.PeopleCount = model.PeopleCount;
            reservation.ReservationTime = model.ReservationTime;
            reservation.Comment = model.Comment;
            reservation.UserId = model.UserId;
            reservation.RestaurantId = model.ResraurantId;
            ReservationsRepository repo = new ReservationsRepository();
            repo.Update(reservation);

            return RedirectToAction("Index");



        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Delete(Reservation reservation)
        {
            ReservationsRepository rep = new ReservationsRepository();

            rep.Delete(reservation);
            return RedirectToAction("Index");
        }

    }
}