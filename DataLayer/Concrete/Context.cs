using EntityLayer.Concrete;
using System.Data.Entity;

namespace DataLayer.Concrete
{
    public class Context:DbContext
    {
         public Context():base("VezneDb") 
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Borrow> borrows { get; set; }
        public DbSet<BookMovement> bookMovements { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Member> members { get; set; }
        public DbSet<MovementType> movementType { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Penalty> penalties { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Publisher> publishers { get; set; }

    }
}
