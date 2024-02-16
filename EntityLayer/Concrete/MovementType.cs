using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class MovementType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; } 
        public DateTime EditDate { get; set; }
        public int EditId { get; set; }
        public virtual ICollection<BookMovement> BookMovement { get; set; }
    }
}
