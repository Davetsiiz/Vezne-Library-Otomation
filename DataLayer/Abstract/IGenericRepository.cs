    using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        void Insert(T t);
        void Delete(T t);
        void Delete(int id);
        void Update(T t);
        List<T> GetListAll();
        T GetById(int id);
        List<T> GetListAll(Expression<Func<T, bool>> filter);
        T GetByFilter(Expression<Func<T, bool>> filter);
    }
}
