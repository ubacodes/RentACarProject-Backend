using BusinessLayer.Concrete;
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

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araç Tanımı: " + car.Description + "\n" + "Araç Modeli: " + car.ModelYear + "\n");
            }

            CarAdd(carManager);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araç Tanımı: " + car.Description + "\n" + "Araç Modeli: " + car.ModelYear + "\n");
            }

            CarUpdate(carManager);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araç Tanımı: " + car.Description + "\n" + "Araç Modeli: " + car.ModelYear + "\n");
            }

            CarDelete(carManager);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Araç Tanımı: " + car.Description + "\n" + "Araç Modeli: " + car.ModelYear + "\n");
            }

            GetCarsByBrandId(carManager);

            GetCarsByColorId(carManager);

        }
        static void CarAdd(CarManager carManager)
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
            addCar.DailyPrice= dailyPrice;
            addCar.Description = description;

            carManager.Add(addCar);
        }

        static void CarDelete(CarManager carManager)
        {
            int id;
            Console.WriteLine("Silinmesini istediğiniz aracın id bilgisini giriniz: \n");
            id = Convert.ToInt32(Console.ReadLine());

            carManager.Delete(id);
        }

        static void CarUpdate(CarManager carManager)
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
            updateCar.DailyPrice= dailyPrice;
            updateCar.ModelYear = modelYear;
            updateCar.Description = description;

            carManager.Update(updateCar);
        }

        static void GetCarsByColorId(CarManager carManager)
        {
            int id;
            Console.WriteLine("Renge göre araçları listelemek için renk kodu id'sini giriniz : ");
            id = Convert.ToInt32(Console.ReadLine());

            foreach (var car in carManager.GetCarsByColorId(id))
            {
                Console.WriteLine("Araç Tanımı: " + car.Description + "\n" + "Araç Modeli: " + car.ModelYear + "\n");
            }

            carManager.GetCarsByColorId(id);
        }

        static void GetCarsByBrandId(CarManager carManager)
        {
            int id;
            Console.WriteLine("Markaya göre araçları listelemek için markasının id'sini giriniz : ");
            id = Convert.ToInt32(Console.ReadLine());

            foreach (var car in carManager.GetCarsByBrandId(id))
            {
                Console.WriteLine("Araç Tanımı: " + car.Description + "\n" + "Araç Modeli: " + car.ModelYear + "\n");
            }

            carManager.GetCarsByBrandId(id);
        }

    }
}