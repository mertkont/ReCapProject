﻿using System;
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
    }
}