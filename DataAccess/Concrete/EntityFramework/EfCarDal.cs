using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<Car> GetById(Expression<Func<Car, bool>> filter, int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetail3Dto> GetCars()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                    join j in context.Colors on c.ColorId equals j.ColorId
                    join b in context.Brands on c.BrandId equals b.BrandId
                    select new CarDetail3Dto { CarName = c.Description, BrandName = b.BrandName, ColorName = j.ColorName, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }
    }
}