using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IProductService
    {
        // Bussiness katmanında kullanacağımız servis kodları

        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id); //CategoryId'ye göre getirir
        List<Product> GetAllByUnitPrice(decimal min, decimal max);
        
    }
}
