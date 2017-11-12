using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using System.Data.Entity;

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
    }
}
