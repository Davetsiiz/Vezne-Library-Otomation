using BusinnessLayer.Abstract;
using DataLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinnessLayer.Concrete
{
    public class BookManager : IBookService
    {
        IBookDal _bookDal;
        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public void Delete(int id)
        {
            _bookDal.Delete(id);
        }

        public List<Book> GetBookById(int id)
        {
            return _bookDal.GetBookById(id);
        }

        public Book GetByFilter(Expression<Func<Book, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetList()
        {
            return _bookDal.GetListAll();
        }

        public void TAdd(Book t)
        {
            _bookDal.Insert(t);
        }

        public void TDelete(Book t)
        {
            _bookDal.Delete(t);
        }

        public Book TGetById(int id)
        {
            return _bookDal.GetById(id);
        }

        public void TUpdate(Book t)
        {
           _bookDal.Update(t);
        }
    }
}
