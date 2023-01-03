using Rasyotek.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Uow
{
    public interface IUow
    {
        IEmployeeRep _EmployeeRep { get; }
        IDebitRep _DebitRep { get; }
        IDebitDetailRep _DebitDetailRep { get; }
        bool Commit();
    }
}
