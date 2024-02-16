using BusinnessLayer.Abstract;
using DataLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinnessLayer.Concrete
{
    public class MemberManager : IMemberService
    {

        IMemberDal _memberDal;
        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;
        }

        public void Delete(int id)
        {
            _memberDal.Delete(id);
        }

        public Member GetByFilter(Expression<Func<Member, bool>> filter)
        {
            return _memberDal.GetByFilter(filter);
        }

        public List<Member> GetList()
        {
            return _memberDal.GetListAll();
        }

        public void TAdd(Member t)
        {
            _memberDal.Insert(t);
        }

        public void TDelete(Member t)
        {
            _memberDal.Delete(t);
        }

        public Member TGetById(int id)
        {
            return _memberDal.GetById(id);
        }

        public void TUpdate(Member t)
        {
            _memberDal.Update(t);
        }
    }
}
