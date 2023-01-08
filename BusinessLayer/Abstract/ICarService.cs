using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetCarsByBrandId(int brandId);
        List<CarDetailDto> GetAllCarDetails();


        void Add(Car car);
        void Delete(int id);
        void Update(Car car);

    }
}
