using Rasyotek.Core;
using Rasyotek.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Repository.Abstract
{
    public interface IDebitRep : IBaseRepository<Debit>
    {
        public void AddDebit();
    }
}
