using System.Collections.Generic;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IColorDal : IEntityRepository<Color>
    {
        List<CarDetail2Dto> GetCarsByColorId(int id);
    }
}