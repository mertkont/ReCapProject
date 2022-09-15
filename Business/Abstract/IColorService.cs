using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<List<CarDetail2Dto>> GetCarsByColorId(int id);
        IDataResult<List<Color>> GetById(int id);
        IResult Add(Color color);
    }
}