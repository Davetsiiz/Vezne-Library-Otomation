using DataLayer.Abstract;
using DataLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.EntityFramework
{
    public class EfBookDal : GenericRepository<Book>, IBookDal
    {
     
        public List<Book> GetBookById(int id)
        {
            using (var c = new Context())
            {
                return c.books.Include("Auther").Include("Publisher").Where(x => x.Id == id).ToList();
            }
        }
    }
}
