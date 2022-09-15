using System;
using System.IO.Enumeration;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // FirstHomework();

            // GetCarsByBrandIdMethod();

            // GetCarsByColorIdMethod();

            // AddActions();

            // GetByIds();

            // GetAlls();

            // DeleteActions();

            // UpdateCommands();

            // TripleTableJoin();
        }

        private static void TripleTableJoin()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCars();
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
            }
        }

        private static void UpdateCommands()
        {
            EfCarDal carDal = new EfCarDal();
            carDal.Update(new Car
                { Id = 8, Description = "Mustafa", BrandId = 2, ColorId = 1, DailyPrice = 500, ModelYear = 1997 });

            EfBrandDal brandDal = new EfBrandDal();
            brandDal.Update(new Brand { BrandId = 4, BrandName = "BMW" });

            EfColorDal colorDal = new EfColorDal();
            colorDal.Update(new Color { ColorId = 4, ColorName = "Pink" });
        }

        private static void DeleteActions()
        {
            EfColorDal colorDal = new EfColorDal();
            colorDal.Add(new Color { ColorId = 4, ColorName = "Purple" });

            EfBrandDal brandDal = new EfBrandDal();
            brandDal.Delete(new Brand { BrandId = 4 });

            EfCarDal carDal = new EfCarDal();
            carDal.Delete(new Car { Id = 8 });
        }

        private static void GetAlls()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result1 = carManager.GetAll();
            foreach (var car in result1.Data)
            {
                Console.WriteLine(car.Description);
            }

            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result2 = brandManager.GetAll();
            foreach (var brand in result2.Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result3 = colorManager.GetAll();
            foreach (var color in result3.Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void GetByIds()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result1 = brandManager.GetById(2);
            foreach (var brand in result1.Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result2 = colorManager.GetById(1);
            foreach (var color in result2.Data)
            {
                Console.WriteLine(color.ColorName);
            }

            CarManager carManager = new CarManager(new EfCarDal());
            var result3 = carManager.GetById(1);
            foreach (var car in result3.Data)
            {
                Console.WriteLine(car.Description);
            }
        }

        private static void AddActions()
        {
            AddBrand();

            AddCar();

            AddColor();
        }

        private static void AddColor()
        {
            EfColorDal colorDal = new EfColorDal();
            colorDal.Add(new Color { ColorId = 4, ColorName = "Purple" });
        }

        private static void AddCar()
        {
            EfCarDal carDal = new EfCarDal();
            carDal.Add(new Car { Id = 8, Description = "Caner", BrandId = 4, ColorId = 2, DailyPrice = 800, ModelYear = 1998 });
        }

        private static void AddBrand()
        {
            EfBrandDal brandDal = new EfBrandDal();
            brandDal.Add(new Brand { BrandId = 4, BrandName = "Audi" });
        }

        private static void GetCarsByColorIdMethod()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetCarsByColorId(2);
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.ColorName + " - " + car.Description);
            }
        }

        private static void GetCarsByBrandIdMethod()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetCarsByBrandId(3);
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.Description + " - " + car.BrandName);
            }
        }

        private static void FirstHomework()
        {
            Console.WriteLine("GetAll sıralaması");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            var result1 = carManager.GetAll();
            foreach (var car in result1.Data)
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\nID'si 2 olanlar:");
            var result2 = carManager.GetById(2);
            foreach (var car in result2.Data)
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}