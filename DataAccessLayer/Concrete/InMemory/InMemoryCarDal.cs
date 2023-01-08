using DataAccessLayer.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brand;
        List<Color> _color;

        public InMemoryCarDal()
        {
            _brand= new List<Brand>
            {
                new Brand{Id = 1, BrandName = "Mercedes"},
                new Brand{Id = 2, BrandName = "Bmw"},
                new Brand{Id = 3, BrandName = "Alfa Romeo"},
                new Brand{Id = 4, BrandName = "Volkswagen"},
                new Brand{Id = 5, BrandName = "Porsche"}
            };

            _color = new List<Color>
            {
                new Color{Id = 1, ColorName = "Siyah"},
                new Color{Id = 2, ColorName = "Red"},
                new Color{Id = 3, ColorName = "White"},
                new Color{Id = 4, ColorName = "Yellow"},
                new Color{Id = 5, ColorName = "Blue"}
            };

            _cars = new List<Car>
            {
                new Car {Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 700, ModelYear = 2020, Description = "Mercedes C180 AMG"},
                new Car {Id = 2, BrandId = 3, ColorId = 2, DailyPrice = 700, ModelYear = 2022, Description = "Alfa Romeo Giulia"},
                new Car {Id = 3, BrandId = 2, ColorId = 5, DailyPrice = 700, ModelYear = 2015, Description = "Bmw F82 4 Series Coupe"},
                new Car {Id = 4, BrandId = 5, ColorId = 4, DailyPrice = 1500, ModelYear = 2021, Description = "Porsche 911 Carrera Turbo S"},
                new Car {Id = 5, BrandId = 1, ColorId = 3, DailyPrice = 400, ModelYear = 2019, Description = "Mercedes A180 Comfort"},
                new Car {Id = 6, BrandId = 4, ColorId = 4, DailyPrice = 800, ModelYear = 2021, Description = "Volkswagen Golf 7 R Line"},
                new Car {Id = 7, BrandId = 3, ColorId = 1, DailyPrice = 700, ModelYear = 2021, Description = "Alfa Romeo Giulia"},
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            // kaydının silinmesini istediğimiz car nesnemizin id si üzerinden erişip referansını silelim

            Car carToDelete;    //bizim için ilgili silinecek car nesnesinin referans tutucusu 
            carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars.ToList();
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            List<Car> getByBrandId;
            getByBrandId = _cars.Where(c => c.BrandId == brandId).ToList();
            return getByBrandId;
        }

        public List<Car> GetById(int carId)
        {
            List<Car> getById;
            getById = _cars.Where(c => c.Id == carId).ToList();
            return getById;
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;          
        }
    }
}
