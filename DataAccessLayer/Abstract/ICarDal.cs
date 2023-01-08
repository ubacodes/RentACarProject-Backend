using Entities.Concrete;
using Entities.DTOs;
using Core.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        // bu imza ile işaretlenmiş classlarım dataaccesslayer katmanımda car nesnemin veri tabanı yönetim işlemlerinden sorumludur. CRUD operasyonları

        List<CarDetailDto> GetAllCarDetails();
    }
}
