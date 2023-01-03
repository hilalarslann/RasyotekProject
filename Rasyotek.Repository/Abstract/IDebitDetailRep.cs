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
    public interface IDebitDetailRep : IBaseRepository<EmployeeDebits>
    {
        public List<DebitDetailDTO> ListDebitDetail(int empId);
        public bool AddRange(List<int> debits, int employeeId);
    }
}
