using BusinnessLayer.Abstract;
using DataLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinnessLayer.Concrete
{
    public class PublisherManager : IPublisherService
    {
        IPublisherDal _publisherDal;
        public PublisherManager(IPublisherDal publisherDal)
        {
            _publisherDal = publisherDal;
        }

        public void Delete(int id)
        {
            _publisherDal.Delete(id);
        }

        public Publisher GetByFilter(Expression<Func<Publisher, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Publisher> GetList()
        {
            return _publisherDal.GetListAll();
        }

        public void TAdd(Publisher t)
        {
            _publisherDal.Insert(t);
        }

        public void TDelete(Publisher t)
        {
            _publisherDal.Delete(t);
        }

        public Publisher TGetById(int id)
        {
            return _publisherDal.GetById(id);
        }

        public void TUpdate(Publisher t)
        {
            _publisherDal.Update(t);
        }
    }
}
