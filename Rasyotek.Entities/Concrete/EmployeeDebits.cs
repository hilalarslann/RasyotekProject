using Rasyotek.Entities.Abstract;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rasyotek.Entities.Concrete
{
    public class EmployeeDebits : BaseEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int DebitId { get; set; }
        public Debit Debit { get; set; }
    }
}
