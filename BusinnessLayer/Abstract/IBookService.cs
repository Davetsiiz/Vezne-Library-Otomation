using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinnessLayer.Abstract
{
    public interface IBookService:IGenericService<Book>
    {
        List<Book> GetBookById(int id);
    }
}
