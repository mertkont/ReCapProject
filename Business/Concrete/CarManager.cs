using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetById(int id)
        {
            return _carDal.GetById(c => c.Id == id, id);
        }

        public void Add(Car car)
        {
            if (car.Description.Length < 2 && car.DailyPrice < 0)
            {
                Console.WriteLine("What're you doin'?");
            }
            else
            {
                _carDal.Add(car);
            }
        }
    }
}