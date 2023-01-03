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
    public class DebitDetailRep<T> : BaseRepository<EmployeeDebits>, IDebitDetailRep where T : class
    {
        public DebitDetailRep(RasyotekContext db) : base(db)
        {
        }
        public List<DebitDetailDTO> ListDebitDetail(int empId)
        {
            var a = Set().Where(x => x.EmployeeId == empId).Select(x => new DebitDetailDTO
            {
                Id = x.Id,
                DebitName = x.Debit.Name,
            }).ToList();
            return a;
        }

        public bool AddRange(List<int> debits, int employeeId)
        {
            var list = new List<EmployeeDebits>();
            var employeeDebits = new EmployeeDebits();

            foreach (var item in debits)
            {
                employeeDebits.DebitId = item;
                employeeDebits.EmployeeId = employeeId;

                list.Add(employeeDebits);
            }

            return AddRange(list);
        }

        
    }
}
