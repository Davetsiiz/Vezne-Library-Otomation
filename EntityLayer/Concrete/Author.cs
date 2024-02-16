using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateId { get; set; }
        public DateTime EditDate { get; set; } 
        public int EditId { get; set; }
        public virtual ICollection<Book> Books { get; set; }

       
    }
}
