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
    public class DebitRep<T> : BaseRepository<Debit>, IDebitRep where T : class
    {
        public DebitRep(RasyotekContext db) : base(db)
        {
        }

        //Bu kısım normalde bu şekilde olamayacak.
        ///sadece veritabanında örnek zimmetler olsun diye reactta tetikleyeceğim burayı
        public void AddDebit()
        {
            Debit d1 = new Debit { Name = "Tablet" };
            Debit d2 = new Debit { Name = "PC" };
            Debit d3 = new Debit { Name = "Araba" };
            Debit d4 = new Debit { Name = "Telefon" };
            Add(d1);
            Add(d2);
            Add(d3);
            Add(d4);
        }
    }
}
