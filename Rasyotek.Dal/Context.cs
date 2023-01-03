using Microsoft.EntityFrameworkCore;
using Rasyotek.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Dal
{
    public class RasyotekContext : DbContext
    {
        public RasyotekContext(DbContextOptions<RasyotekContext> db) : base(db)
        {

        }
        DbSet<Employee> Employees { get; set; }
        DbSet<Debit> Debits { get; set; }
        DbSet<EmployeeDebits> EmployeeDebits { get; set; }
    }
}
