using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        List<CarDetailDto> GetCarsByBrandId(int id);
    }
}