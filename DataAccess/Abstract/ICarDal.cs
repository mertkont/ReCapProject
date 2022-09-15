using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<Car> GetById(Expression<Func<Car, bool>> filter, int id);
    }
}