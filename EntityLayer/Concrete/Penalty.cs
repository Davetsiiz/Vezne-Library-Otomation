using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Penalty
    {
        [Key]
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Detail { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateId { get; set; }
        public DateTime EditDate { get; set; }
        public int EditId { get; set; }
        public virtual Member Members { get; set; }
    }
}
