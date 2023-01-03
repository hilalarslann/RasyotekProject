using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Core
{
    public interface IBaseRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> List(Expression<Func<T, bool>> filter = null);
        T Find(int Id);
        T Add(T entity);
        bool AddRange(List<T> entities);
        bool Update(T entity);
        bool Delete(int Id);
        DbSet<T> Set();
    }
}
