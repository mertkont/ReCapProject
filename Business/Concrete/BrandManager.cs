using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        
        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<CarDetailDto> GetCarsByBrandId(int id)
        {
            return _brandDal.GetCarsByBrandId(id);
        }
    }
}