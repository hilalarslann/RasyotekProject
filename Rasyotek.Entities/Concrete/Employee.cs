using Rasyotek.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Rasyotek.Entities.Concrete
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Gender { get; set; }
        public string GraduatedSchool { get; set; }
        public ICollection<EmployeeDebits>? EmployeeDebits { get; set; }
        public enum Genders
        {
            Erkek, Kadın, Diğer
        }
        public Genders GetGender()
        {
            if (Gender == 0)
                return Genders.Erkek;
            else if (Gender == 1)
                return Genders.Kadın;
            else
                return Genders.Diğer;
        }
    }
}
