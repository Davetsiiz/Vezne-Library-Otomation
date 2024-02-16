using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public int PublisherId { get; set; }
        public int Piece { get; set; }
        public string Barcode { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateId { get; set; }
        public DateTime EditDate { get; set; }
        public int EditId { get; set; }
        public virtual ICollection<Borrow> borrows { get; set; }
        public virtual ICollection<BookMovement> bookMovements { get; set; }
        public virtual Author Auther { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
