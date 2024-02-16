using BusinnessLayer.Abstract;
using DataLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinnessLayer.Concrete
{
    public class BorrowManager : IBorrowService
    {
        IBorrowDal _borrowDal;
        public BorrowManager(IBorrowDal borrowDal)
        {
            _borrowDal = borrowDal;
        }

        public void Delete(int id)
        {
            _borrowDal.Delete(id);
        }

        public Borrow GetByFilter(Expression<Func<Borrow, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Borrow> GetList()
        {
            return _borrowDal.GetListAll();
        }

        public void TAdd(Borrow t)
        {
            _borrowDal.Insert(t);
        }

        public void TDelete(Borrow t)
        {
            _borrowDal.Delete(t);
        }

        public Borrow TGetById(int id)
        {
            return _borrowDal.GetById(id);
        }

        public void TUpdate(Borrow t)
        {
            _borrowDal.Update(t);
        }
    }
}
