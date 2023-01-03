using Microsoft.EntityFrameworkCore;
using Rasyotek.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Core
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        RasyotekContext _db;
        public BaseRepository(RasyotekContext db)
        {
            _db = db;
        }
        public T Add(T entity)
        {
            Set().Add(entity);
            return entity;
        }

        public bool AddRange(List<T> entities)
        {
            try
            {
                Set().AddRange(entities);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                Set().Remove(Find(Id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T Find(int Id)
        {
            return Set().Find(Id);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return Set().FirstOrDefault(filter);
        }

        public List<T> List(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ? Set().ToList() : Set().Where(filter).ToList();
        }

        public DbSet<T> Set()
        {
            return _db.Set<T>();
        }

        public bool Update(T entity)
        {
            try
            {
                Set().Update(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
