using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Rasyotek.Core;
using Rasyotek.Dal;
using Rasyotek.DTO;
using Rasyotek.Entities.Concrete;
using Rasyotek.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Repository.Concrete
{
    public class EmployeeRep<T> : BaseRepository<Employee>, IEmployeeRep where T : class
    {
        public EmployeeRep(RasyotekContext db) : base(db)
        {

        }

        public List<EmployeeModel> ListEmployee()
        {
            var emp = Set().Select(x => new EmployeeModel
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Gender = Convert.ToInt32(x.GetGender()),
                GraduatedSchool = x.GraduatedSchool,
            }).ToList();

            return emp;
        }

        public Employee AddEmployee(EmployeeDTO employee)
        {
            return  Add(new Employee
            {
                Name = employee.Name,
                Surname = employee.Surname,
                Gender = employee.Gender,
                GraduatedSchool = employee.GraduatedSchool,
            });
        }
        public void UpdateEmployee(int id, EmployeeDTO employee)
        {
            Employee e = Find(id);
            e.Name = employee.Name;
            e.Surname = employee.Surname;
            e.Gender = employee.Gender;
            //e.Debit = employee.Debit;
            e.GraduatedSchool = employee.GraduatedSchool;
        }
    }
}
