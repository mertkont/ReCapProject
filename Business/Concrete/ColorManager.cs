using System.Collections.Generic;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<List<CarDetail2Dto>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetail2Dto>>(_colorDal.GetCarsByColorId(id));
        }

        public IDataResult<List<Color>> GetById(int id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId == id));
        }
        
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            if (color.ColorName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.CarAdded);
        }
        
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new Result(true, Messages.CarUpdated);
        }
    }
}