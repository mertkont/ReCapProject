using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<Car> GetById(Expression<Func<Car, bool>> filter, int id);
        List<CarDetail3Dto> GetCars();
        List<CarDetail4Dto> GetCarDetail4Dtos();
        List<CarDetail5Dto> GetCarsByBrandId(Expression<Func<Car, bool>> filter, int brandId);
        List<CarDetail5Dto> GetCarsByColorId(Expression<Func<Car, bool>> filter, int colorId);
    }
}