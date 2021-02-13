using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var car in carManager.GetCarsByBrandId(1))
            //{
            //    Console.WriteLine(car.CarName);
            //}
            //foreach (var car in carManager.GetCarsByColorId(2))
            //{
            //    Console.WriteLine(car.CarName);
            //}

            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {

                    Console.WriteLine(car.CarName + "/" + car.CarName + "/" +car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            //carManager.Add(new Car { Id = 1, CarName = "Araba", BrandId = 1, ColorId = 1, DailyPrice = 500, ModelYear = new DateTime(2020, 3, 5), Description = "Manuel" });
            //carManager.Add(new Car { Id = 2, CarName = "Araba", BrandId = 1, ColorId = 2, DailyPrice = 500, ModelYear = new DateTime(2020, 3, 5), Description = "Otomatik" });
            //carManager.Add(new Car { Id = 3, CarName = "Araba", BrandId = 2, ColorId = 1, DailyPrice = 500, ModelYear = new DateTime(2020, 3, 5), Description = "Otomatik" });
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.CarName);
            //}
            //brandManager.Add(new Brand { Id = 1, Name = "Mercedes" });
            //brandManager.Add(new Brand { Id = 2, Name = "BMW" });
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.Name);
            //}

            //colorManager.Add(new Color { Id = 1, Name = "Siyah" });
            //colorManager.Add(new Color { Id = 2, Name = "Beyaz" });
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.Name);
            //}

            //SİLME İŞLEMİ
            //carManager.Delete(new Car { Id = 8 }); 

            //Console.WriteLine("----------------------- SİLİNEN ARAÇ SONRASI TÜM ARAÇLAR ---------------------"); 

            //foreach (var car in carManager.GetAll())
            //{ 
            // Console.WriteLine(car.CarName); 
            //} 
            //GÜNCELLEME İŞLEMİ //carManager.Update(new Car { Id = 7, CarName = "ArabaYedi", BrandId = 1, ColorId = 2, Description = "Klima Var - Otomatik", ModelYear = new DateTime(2021, 1, 9), DailyPrice = 700 }); 

            //Console.WriteLine("----------------------- GÜNCELLENEN ARAÇ SONRASI TÜM ARAÇLAR ---------------------"); 

            //foreach (var car in carManager.GetAll()) 
            //{ 
            // Console.WriteLine(car.CarName); 
            //}

        }
    }
}
