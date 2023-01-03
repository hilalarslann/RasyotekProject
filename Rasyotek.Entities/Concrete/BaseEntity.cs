using Rasyotek.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Rasyotek.Entities.Concrete
{
    public class BaseEntity : IBaseTable
    {
        [Key]
        public int Id { get; set; }
    }
}
