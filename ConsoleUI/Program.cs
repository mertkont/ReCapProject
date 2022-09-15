using System;
using Business.Concrete;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
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