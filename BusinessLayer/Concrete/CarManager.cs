using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal= carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araç eklenirken bir sorun oluştu! Ekleme işlemi kurallara uygun olmayabilir tekrar kontrol ediniz!");
            }
        }

        public void Delete(int id)
        {
            List<Car> carList = _carDal.GetAll();
            Car deletedCar = new Car();

            foreach (var car in carList)
            {
                if (car.Id == id)
                {
                    deletedCar.Id = car.Id;
                    deletedCar.BrandId = car.BrandId;
                    deletedCar.ColorId = car.ColorId;
                    deletedCar.ModelYear = car.ModelYear;
                    deletedCar.DailyPrice = car.DailyPrice;
                    deletedCar.Description = car.Description;
                }
            }

            _carDal.Delete(deletedCar);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }
    }
}
