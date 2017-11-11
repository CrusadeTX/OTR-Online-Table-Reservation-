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

        }
        public List<Reservation> GetAll()
        {
            return dbSet.ToList();
        }

        public Reservation Get(int id)
        {
            return dbSet.Find(id);
        }
        public Reservation Insert (Reservation entity)
        {
            return dbSet.Add(entity);
            db.SaveChanges();
        }
        public void Update(Reservation entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
