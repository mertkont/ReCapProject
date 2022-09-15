using System.Collections.Generic;
using System.Linq;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarRentalContext>, IColorDal
    {
        public List<CarDetail2Dto> GetCarsByColorId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join j in context.Colors
                             on c.BrandId equals j.ColorId
                             where j.ColorId == id
                             select new CarDetail2Dto { ColorName = j.ColorName, Description = c.Description };
                return result.ToList();
            }
        }
    }
}