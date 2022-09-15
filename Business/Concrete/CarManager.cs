using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2 && car.DailyPrice < 200)
            {
                return new ErrorResult(Messages.CarCannotAdd);
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
    }
}