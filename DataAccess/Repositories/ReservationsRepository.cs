using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Data.Entity;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
   public class ReservationsRepository
    {
        private DbContext db;
        private DbSet<Reservation> dbSet;
        public ReservationsRepository()
        {
            db = new BookATableContext();
            dbSet = db.Set<Reservation>();
        }
        public List<Reservation> GetAll()
        {
            return dbSet.ToList();
        }

        public Reservation Get(int id)
        {
            return dbSet.Find(id);
        }
        public void Insert (Reservation entity)
        {
            db.Entry(entity).State = EntityState.Added;
            db.SaveChanges();
        }
        public void Update(Reservation entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(Reservation entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public List<Reservation> GetActive()
        {
            List<Reservation> rev = new List<Reservation>();
            rev = GetAll();
            List<Reservation> result = new List<Reservation>();
            foreach (Reservation res in rev)
            {
                if (DateTime.Now < res.ReservationTime)
                {
                    result.Add(res);
                }
            }

            return result;
        }

        //public List<Reservation> GetCompleted()
        //{
        //    List<Reservation> rev = new List<Reservation>();
        //    rev = GetAll();
        //    List<Reservation> result = new List<Reservation>();
        //    foreach (Reservation res in rev)
        //    {
        //        if (DateTime.Now > res.ReservationTime)
        //        {
        //            result.Add(res);
        //        }
        //    }

        //    return result;
        //}


        public List<Reservation> GetAll(/*Expression<Func<Reservation, bool>> filter,*/ DateTime time)
        {
            List<Reservation> result = GetAll()
            .Where(t => t.ReservationTime > time && t.ReservationTime < DateTime.Now)
            .OrderBy(t => t.UserId)
            .Take(3).ToList();


            return result;
            //return dbSet.Where(filter).Take(2).ToList();
        }
    }
}
