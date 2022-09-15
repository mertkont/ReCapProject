using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 3, ColorId = 2, ModelYear = 1995, DailyPrice = 500, Description = "Toros" },
                new Car { Id = 2, BrandId = 2, ColorId = 3, ModelYear = 1996, DailyPrice = 700, Description = "Tofas" },
                new Car { Id = 3, BrandId = 2, ColorId = 3, ModelYear = 1996, DailyPrice = 600, Description = "Ferrari" },
                new Car { Id = 4, BrandId = 3, ColorId = 3, ModelYear = 1996, DailyPrice = 400, Description = "Lamborghini" },
                new Car { Id = 5, BrandId = 1, ColorId = 2, ModelYear = 1997, DailyPrice = 700, Description = "Mercedes-Benz" },
                new Car { Id = 6, BrandId = 1, ColorId = 1, ModelYear = 1997, DailyPrice = 700, Description = "BMW" },
                new Car { Id = 7, BrandId = 3, ColorId = 1, ModelYear = 1995, DailyPrice = 800, Description = "Audi" },
            };
        }
        
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars.ToList();
        }

        public List<Car> GetById(Expression<Func<Car, bool>> filter, int id)
        {
            return _cars.Where(c => c.Id == id).ToList();
        }

        public List<CarDetail3Dto> GetCars()
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car deleteCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(deleteCar);
        }

        public void Update(Car car)
        {
            Car updateCar = _cars.SingleOrDefault(c => c.Id == car.Id);
            updateCar.Id = car.Id;
            updateCar.BrandId = car.BrandId;
            updateCar.ColorId = car.ColorId;
            updateCar.ModelYear = car.ModelYear;
            updateCar.DailyPrice = car.DailyPrice;
            updateCar.Description = car.Description;
        }
    }
}