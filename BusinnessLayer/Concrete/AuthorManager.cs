using BusinnessLayer.Abstract;
using DataLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinnessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        IAuthorDal _autherDal;
        public AuthorManager(IAuthorDal autherDal)
        {
            _autherDal = autherDal;
        }

        public void Delete(int id)
        {
            _autherDal.Delete(id);
        }

        public Author GetByFilter(Expression<Func<Author, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetList()
        {
            return _autherDal.GetListAll();
        }

        public void TAdd(Author t)
        {
            _autherDal.Insert(t);
        }

        public void TDelete(Author t)
        {
            _autherDal.Delete(t);
        }

        public Author TGetById(int id)
        {
            return _autherDal.GetById(id);
        }

        public void TUpdate(Author t)
        {
            _autherDal.Update(t);
        }
    }
}
