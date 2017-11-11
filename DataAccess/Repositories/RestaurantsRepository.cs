using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class RestaurantsRepository
    {
        private DbContext db;
        private DbSet<Restaurant> dbSet;
        public RestaurantsRepository()
        {
            db = new BookATableContext();
            dbSet = db.Set<Restaurant>();
        }
        public List<Restaurant> GetAll()
        {
            return dbSet.ToList();
        }

        public Restaurant Get(int id)
        {
            return dbSet.Find(id);
        }
        public void Insert(Restaurant entity)
        {
            db.Entry(entity).State = EntityState.Added;
            db.SaveChanges();
            
            
        }
        public void Update(Restaurant entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(Restaurant entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}
