using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Autofac.Features.ResolveAnything;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentalsDto> GetRentals()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                    join k in context.Cars on r.CarId equals k.Id
                    join b in context.Brands on k.BrandId equals b.BrandId
                    join c in context.Customers on r.CustomerId equals c.CustomerId
                    select new RentalsDto { RentalId = r.RentalId, BrandName = b.BrandName, FirstName = c.CompanyName, RentDate = r.RentDate, ReturnDate = r.ReturnDate};
                return result.ToList();
            }
        }

    }
}