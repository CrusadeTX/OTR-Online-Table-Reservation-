using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataAccess.Repositories
{
    public class UnitOfWork
    {
        internal BookATableContext DbContext { get; set; }
        public  DbContextTransaction Trans { get; set; }

        public UnitOfWork()
        {
            DbContext = new BookATableContext();
        }
        public void Start()
        {
            Trans = DbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (Trans != null)
                Trans.Commit();
        }

        public void Rollback()
        {
            if (Trans != null)
                Trans.Rollback();
        }
    }
}
