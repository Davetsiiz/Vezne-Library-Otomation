using System;
using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public class Member
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateId { get; set; }
        public DateTime EditDate { get; set; }
        public int EditId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Borrow> Borrow { get; set; }
        public virtual ICollection<BookMovement> BookMovement { get; set; }
        public virtual ICollection<Penalty> Penalties { get; set; }
       
    }
}
