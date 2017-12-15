using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccess.Repositories;
using DataAccess.Entities;
using BookATableWeb.ViewModels;
using BookATableWeb.Models;

namespace BookATableWeb.Controllers
{
    [Authorize(Roles = "Customer,Manager,Admin")]
    public class ReservationsController : Controller
    {
        // GET: Reservations
        public ActionResult Index()
        {

            ReservationsRepository repository = new ReservationsRepository();
            ReservationsListViewModel model = new ReservationsListViewModel();

            RestaurantsRepository rep = new RestaurantsRepository();
            UsersRepository repo = new UsersRepository();

            List<Reservation> reservations = repository.GetActive();
            List<Restaurant> restaurants = rep.GetAll();
            List<User> users = repo.GetAll();
            
            model.Reservation = reservations;
            model.Restaurants = restaurants;
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
        [Authorize(Roles = "Manager,Admin")]
        public ActionResult MostVisited()
        {
            MostVisitedCreateViewModel mostVisited = new MostVisitedCreateViewModel();
            DateTime dateWeek = DateTime.Now.AddDays(-7);
            DateTime dateMonth = DateTime.Now.AddMonths(-1);
            DateTime dateYear = DateTime.Now.AddYears(-1);
            ReservationsRepository repository = new ReservationsRepository();
            RestaurantsRepository rep = new RestaurantsRepository();
            List<Restaurant> restaurants = rep.GetAll();
            mostVisited.Restaurants = restaurants;
            UsersRepository repo = new UsersRepository();
            List<User> users = repo.GetAll();
            mostVisited.Users = users;
            //mostVisited.mostVisitedWeekly = repository.GetAll(n => n.ReservationTime > dateWeek && n.ReservationTime < DateTime.Now);
            mostVisited.mostVisitedWeekly = repository.GetAll(dateWeek);
            mostVisited.mostVisitedMonthly = repository.GetAll(dateMonth);
            mostVisited.mostVisitedYearly = repository.GetAll(dateYear);
            //mostVisited.mostVisitedMonthly = repository.GetAll(n => n.ReservationTime > dateMonth && n.ReservationTime < DateTime.Now);
            //mostVisited.mostVisitedYearly = repository.GetAll(n => n.ReservationTime > dateYear && n.ReservationTime < DateTime.Now);
            return View(mostVisited);
            
        }

    }
}