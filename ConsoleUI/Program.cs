using System;
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

            GetCarsByColorIdMethod();
        }

        private static void GetCarsByColorIdMethod()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var car in colorManager.GetCarsByColorId(2))
            {
                Console.WriteLine(car.ColorName + " - " + car.Description);
            }
        }

        private static void GetCarsByBrandIdMethod()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var car in brandManager.GetCarsByBrandId(3))
            {
                Console.WriteLine(car.Description + " - " + car.BrandName);
            }
        }

        private static void FirstHomework()
        {
            Console.WriteLine("GetAll sıralaması");
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\nID'si 2 olanlar:");
            foreach (var car in carManager.GetById(2))
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}