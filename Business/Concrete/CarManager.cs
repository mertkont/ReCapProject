using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == id));
        }

        public IDataResult<List<CarDetail3Dto>> GetCars()
        {
            return new SuccessDataResult<List<CarDetail3Dto>>(_carDal.GetCars());
        }

        public IDataResult<List<CarDetail4Dto>> GetCarsWithBrandColorName()
        {
            return new SuccessDataResult<List<CarDetail4Dto>>(_carDal.GetCarDetail4Dtos());
        }

        public IDataResult<List<CarDetail5Dto>> GetCarsByBrandId(Expression<Func<CarDetail5Dto, bool>> filter, int brandId)
        {
            return new SuccessDataResult<List<CarDetail5Dto>>(_carDal.GetCarsByBrandId(c => c.BrandId == brandId, brandId));
        }

        public IDataResult<List<CarDetail5Dto>> GetCarsByColorId(Expression<Func<CarDetail5Dto, bool>> filter, int colorId)
        {
            return new SuccessDataResult<List<CarDetail5Dto>>(_carDal.GetCarsByColorId(c => c.ColorId == colorId, colorId));
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, Messages.CarUpdated);
        }
    }
}