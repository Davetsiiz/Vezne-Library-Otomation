﻿using DataLayer.Abstract;
using DataLayer.Concrete;
using EntityLayer.Concrete;

namespace DataLayer.EntityFramework
{
    public class EfPublisherDal : GenericRepository<Publisher>,IPublisherDal
    {
    }
}
