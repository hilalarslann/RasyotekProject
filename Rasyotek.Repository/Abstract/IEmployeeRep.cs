using Rasyotek.Core;
using Rasyotek.DTO;
using Rasyotek.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Repository.Abstract
{
    public interface IEmployeeRep : IBaseRepository<Employee>
    {
        public List<EmployeeModel> ListEmployee();
        public Employee AddEmployee(EmployeeDTO employee);
        public void UpdateEmployee(int id, EmployeeDTO employee);
    }
}
