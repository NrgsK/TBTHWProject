using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product> //IEntityRepository Product için yapılandı
    {
        //interface'nin metotları default public
        // Add reference
        //Circular dependencies
        //Eğer alternatif bir teknoloji kullanılıyorsa klasörle (concrete)
        List<ProductDetailDto> GetProductDetails();
    }
}

//Code Refactoring - Kodun iyileşitirlmesi