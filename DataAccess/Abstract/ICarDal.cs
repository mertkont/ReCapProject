using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll(Expression<Func<Car, bool>> filter = null);
        List<Car> GetById(Expression<Func<Car, bool>> filter, int id);
        Car Get(Expression<Func<Car, bool>> filter);
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}