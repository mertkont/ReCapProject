using System.Collections.Generic;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetAll();
        List<CarDetail2Dto> GetCarsByColorId(int id);
    }
}