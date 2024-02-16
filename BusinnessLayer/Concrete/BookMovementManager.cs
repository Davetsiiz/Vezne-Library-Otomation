using BusinnessLayer.Abstract;
using DataLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinnessLayer.Concrete
{
    public class BookMovementManager : IBookMovementService
    {
        IBookMovementDal _bookMovementDal;
        public BookMovementManager(IBookMovementDal bookMovementDal)
        {
            _bookMovementDal = bookMovementDal;
        }

        public void Delete(int id)
        {
            _bookMovementDal.Delete(id);
        }

        public BookMovement GetByFilter(Expression<Func<BookMovement, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<BookMovement> GetList()
        {
            return _bookMovementDal.GetListAll();
        }

        public void TAdd(BookMovement t)
        {
            _bookMovementDal.Insert(t);
        }

        public void TDelete(BookMovement t)
        {
            _bookMovementDal.Delete(t);
        }

        public BookMovement TGetById(int id)
        {
            return _bookMovementDal.GetById(id);
        }

        public void TUpdate(BookMovement t)
        {
            _bookMovementDal.Update(t);
        }
    }
}
