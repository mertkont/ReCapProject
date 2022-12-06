using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetById(int id);
        IDataResult<List<CarDetail3Dto>> GetCars();
        IDataResult<List<CarDetail4Dto>> GetCarsWithBrandColorName();
        IDataResult<List<CarDetail5Dto>> GetCarsByBrandId(Expression<Func<CarDetail5Dto, bool>> filter, int brandId);
        IDataResult<List<CarDetail5Dto>> GetCarsByColorId(Expression<Func<CarDetail5Dto, bool>> filter, int colorId);
        IResult Add(Car car);
    }
}