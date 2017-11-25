using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public class UsersRepository
    {

        //Jesus is black
        private DbContext db;
        private DbSet<User> dbSet;
        public UsersRepository()
        {
            db = new BookATableContext();
            dbSet = db.Set<User>();
        }
        public List<User> GetAll()
        {
            return dbSet.ToList();
        }

        public User Get(int id)
        {
            return dbSet.Find(id);
        }
        public void Insert(User entity)
        {
            db.Entry(entity).State = EntityState.Added;
            db.SaveChanges();

        }
        public void Delete(User entity)
        {
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();

        }
        public void Update(User entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
