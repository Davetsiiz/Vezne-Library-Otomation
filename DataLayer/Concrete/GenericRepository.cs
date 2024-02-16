using DataLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;

namespace DataLayer.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public void Delete(T t)
        {
            using (var c = new Context())
            {               
                c.Set<T>().Attach(t);
                c.Set<T>().Remove(t);
                c.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var entity=GetById(id);
            if (entity == null)
            {
                return;
            }
            else
            {
                Delete(entity);
            }
        }

        public T GetByFilter(Expression<Func<T, bool>> filter)
        {
            using (var c = new Context())
            {
                return c.Set<T>().FirstOrDefault(filter);
            }
        }

        public T GetById(int id)
        {
            using (var c = new Context())
            {
                return c.Set<T>().Find(id);
            }
        }

        public List<T> GetListAll()
        {
            using (var c = new Context())
            {
                return c.Set<T>().ToList();
            }
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter)
        {
            using (var c = new Context())
            {
                return filter==null?c.Set<T>().ToList():c.Set<T>().Where(filter).ToList();
            }
        }

        public void Insert(T t)
        {
            using (var c = new Context())
            {
                c.Set<T>().AddOrUpdate(t);
                c.SaveChanges();
            }
        }

        public void Update(T t)
        {
            using (var c = new Context())
            {
                c.Set<T>().AddOrUpdate(t);
                c.SaveChanges();
            }
        }
    }
}
