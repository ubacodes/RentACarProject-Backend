using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.InMemory;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Drawing;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //BrandManager brandManager = new BrandManager(new EfBrandDal);

            GetAllCar(carManager);
            //GetAllCarDetail(carManager);
            //Add(carManager);
            //Update(carManager);
            //Delete(carManager);

            //GetCarsByBrandId(carManager);
            //GetCarsByColorId(carManager);
        }

        static void GetAllCar(CarManager _carManager)
        {
            foreach (var car in _carManager.GetAll())
            {
                Console.WriteLine("Araç Tanımı: " + car.Description + "\n" + "Araç Modeli: " + car.ModelYear + "\n");
            }
        }
        static void GetAllCarDetail(CarManager _carManager)
        {
            foreach (var car in _carManager.GetAllCarDetails())
            {
                Console.WriteLine("Car ID    :" + car.CarId + "\nBrandName :" + car.BrandName + "\nColorName :" + car.ColorName + "\n");
            }
        }
        static void Add(CarManager _carManager)
        {
            int brandId, colorId, modelYear;
            decimal dailyPrice;
            string description;

            Console.WriteLine("Eklemek istediğiniz aracın brandId bilgisini giriniz: \n");
            brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Eklemek istediğiniz aracın colorId bilgisini giriniz: \n");
            colorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Eklemek istediğiniz aracın model yılı bilgisini giriniz: \n");
            modelYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Eklemek istediğiniz aracın günlük kiralama ücretini giriniz: \n");
            dailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Eklemek istediğiniz aracın açıklama / tanımı 'nı giriniz: \n");
            description = Console.ReadLine();

            Car addCar = new Car();
            addCar.BrandId = brandId;
            addCar.ModelYear = modelYear;
            addCar.ColorId = colorId;
            addCar.ModelYear = modelYear;
            addCar.DailyPrice = dailyPrice;
            addCar.Description = description;

            _carManager.Add(addCar);
        }
        static void Delete(CarManager _carManager)
        {
            int id;
            Console.WriteLine("Silinmesini istediğiniz aracın id bilgisini giriniz: \n");
            id = Convert.ToInt32(Console.ReadLine());

            _carManager.Delete(id);
        }
        static void Update(CarManager _carManager)
        {
            int id, brandId, colorId, modelYear;
            decimal dailyPrice;
            string description;

            Console.WriteLine("Güncellemek istediğiniz aracın Id bilgisini giriniz: \n");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Güncellemek istediğiniz aracın brandId bilgisini giriniz: \n");
            brandId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Güncellemek istediğiniz aracın colorId bilgisini giriniz: \n");
            colorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Güncellemek istediğiniz aracın model yılı bilgisini giriniz: \n");
            modelYear = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Güncellemek istediğiniz aracın günlük kiralama ücretini giriniz: \n");
            dailyPrice = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Güncellemek istediğiniz aracın açıklama / tanımı 'nı giriniz: \n");
            description = Console.ReadLine();

            Car updateCar = new Car();
            updateCar.Id = id;
            updateCar.BrandId = brandId;
            updateCar.ModelYear = modelYear;
            updateCar.ColorId = colorId;
            updateCar.DailyPrice = dailyPrice;
            updateCar.ModelYear = modelYear;
            updateCar.Description = description;

            _carManager.Update(updateCar);
        }
        static void GetCarsByColorId(CarManager _carManager)
        {
            int id;
            Console.WriteLine("Renge göre araçları listelemek için renk kodu id'sini giriniz : ");
            id = Convert.ToInt32(Console.ReadLine());

            foreach (var car in _carManager.GetCarsByColorId(id))
            {
                Console.WriteLine("Araç Tanımı: " + car.Description + "\n" + "Araç Modeli: " + car.ModelYear + "\n");
            }

            _carManager.GetCarsByColorId(id);
        }
        static void GetCarsByBrandId(CarManager _carManager)
        {
            int id;
            Console.WriteLine("Markaya göre araçları listelemek için markasının id'sini giriniz : ");
            id = Convert.ToInt32(Console.ReadLine());

            foreach (var car in _carManager.GetCarsByBrandId(id))
            {
                Console.WriteLine("Araç Tanımı: " + car.Description + "\n" + "Araç Modeli: " + car.ModelYear + "\n");
            }

            _carManager.GetCarsByBrandId(id);
        }
    }
}