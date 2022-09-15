using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarRentalContext>, IBrandDal
    {
        public List<CarDetailDto> GetCarsByBrandId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                        join b in context.Brands
                        on c.BrandId equals b.BrandId
                        where b.BrandId == id
                        select new CarDetailDto { BrandId = c.BrandId, Description = c.Description, BrandName = b.BrandName };
                return result.ToList();
            }
        }
    }
}