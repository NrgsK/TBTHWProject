using Bussiness.Abstract;
using Bussiness.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //[ApiController] --> Attribute : bir class ile ilgili imzalama yöntemi. .NET e kendini ona göre yapılandır diyoruz.
        //Route : Kullanıcı nasıl ulaşsın

        //Loosely coupled -- Gevşek bağlılık : Soyuta bağımlılık var
        //naming convention
        //IoC Container -- Inversion of Control 
        IProductService _productService; //Bağımlılıktan kurtarmak için bir injection oluşturuyoruz.

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //Katmanların somutuna bağlı olmamalı.

        [HttpGet]
        public List<Product> Get()
        {
            /*
                return new List<Product>
            {
                new Product{ProductId=1,ProductName="Elma"},
                new Product{ProductId=2,ProductName="Armut"}
            };
            */

            //Dependency chain -- Bağımlılık zinciri
            //IProductService productService = new ProductManager(new EfProductDal()); 
            var result = _productService.GetAll();  //IDataResult döndürür.
            return result.Data;
        }
    }
}
