using Bussiness.Abstract;
using Bussiness.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet("getall")]
        public IActionResult GetAll()
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
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result=_productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
