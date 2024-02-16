using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataLayer.Abstract
{
    public interface IBookDal:IGenericRepository<Book>
    {
         List<Book> GetBookById(int id);
    }
}
