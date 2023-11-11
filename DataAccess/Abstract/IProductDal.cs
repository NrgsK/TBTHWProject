using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        //interface'nin metotları default public
        // Add reference
        //Circular dependencies
        //Eğer alternatif bir teknoloji kullanılıyorsa klasörle (concrete)
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

        List<Product> GetByAllCategory(int categoryId);  //Ürünleri kategoriye göre listeler
    }
}
