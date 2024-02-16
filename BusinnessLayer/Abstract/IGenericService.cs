using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BusinnessLayer.Abstract
{
    public interface IGenericService<T>
    {
        void TAdd(T t);
        void TDelete(T t);
        void Delete(int id);
        void TUpdate(T t);
        List<T> GetList();
        T TGetById(int id);
        T GetByFilter(Expression<Func<T, bool>> filter);
    }
}
