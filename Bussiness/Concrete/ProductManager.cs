using Bussiness.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class ProductManager : IProductService
    {
        //injection
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
           //Constructor
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            // İş kodları
            return _productDal.GetAll();
        }
    }
}
