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
        private DbContext db;
        private DbSet<User> dbSet;
        public UsersRepository()
        {

        }
        public List<User> GetAll()
        {
            return dbSet.ToList();
        }

        public User Get(int id)
        {
            return dbSet.Find(id);
        }
        public User Insert(User entity)
        {
            return dbSet.Add(entity);
            db.SaveChanges();
        }
        public void Update(User entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
