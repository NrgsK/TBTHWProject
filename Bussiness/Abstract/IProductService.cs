using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
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

        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id); //CategoryId'ye göre getirir
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int productId);
        IResult Add(Product product);
        IResult Update(Product product);

        //Restful --> HTTP(internet protokolü) --> 
        //Sisteme istekte bulunuyoruz
        //Controller : Client lar bize nasıl istekte bulunabiliri kontrol eder.
    }
}
