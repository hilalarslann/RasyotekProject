using Rasyotek.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Rasyotek.Entities.Concrete.Employee;

namespace Rasyotek.DTO
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Gender { get; set; }
        public string GraduatedSchool { get; set; }
        public ICollection<EmployeeDebits> EmployeeDebits { get; set; }

    }
}
