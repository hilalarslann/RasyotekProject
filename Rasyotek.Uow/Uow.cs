using Rasyotek.Dal;
using Rasyotek.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Uow
{
    public class Uow :IUow
    {
        RasyotekContext _db;
        public IEmployeeRep _EmployeeRep { get; private set; }
        public IDebitRep _DebitRep { get; private set; }
        public IDebitDetailRep _DebitDetailRep { get; private set; }
        public Uow(RasyotekContext db, IEmployeeRep employeeRep, IDebitRep debitRep, IDebitDetailRep debitDetailRep)
        {
            _db = db;
            _EmployeeRep = employeeRep;
            _DebitRep = debitRep;
            _DebitDetailRep = debitDetailRep;
        }
        public bool Commit()
        {
            return _db.SaveChanges() > 0;
        }
    }
}
