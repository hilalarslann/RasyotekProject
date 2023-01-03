using Rasyotek.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.DTO
{
    public class EmployeeDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Gender { get; set; }
        public string GraduatedSchool { get; set; }
        public List<int>? DebitIdList { get; set; }
    }
}
