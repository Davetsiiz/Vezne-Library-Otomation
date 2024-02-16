using BusinnessLayer.Abstract;
using DataLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinnessLayer.Concrete
{
    public class PenaltyManager : IPenaltyService
    {
        IPenaltyDal _penaltyDal;
        public PenaltyManager(IPenaltyDal penaltyDal)
        {
            _penaltyDal = penaltyDal;
        }

        public void Delete(int id)
        {
           _penaltyDal.Delete(id);
        }

        public Penalty GetByFilter(Expression<Func<Penalty, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Penalty> GetList()
        {
            return _penaltyDal.GetListAll();
        }

        public void TAdd(Penalty t)
        {
            _penaltyDal.Insert(t);
        }

        public void TDelete(Penalty t)
        {
            _penaltyDal.Delete(t);
        }

        public Penalty TGetById(int id)
        {
            return _penaltyDal.GetById(id);
        }

        public void TUpdate(Penalty t)
        {
            _penaltyDal.Update(t);
        }
    }
}
