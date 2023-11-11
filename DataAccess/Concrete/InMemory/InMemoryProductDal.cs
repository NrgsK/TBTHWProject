﻿using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products; //Metotların dışında tanımnlanır.Global Değişken
        public InMemoryProductDal()
        {
            // Constructor
            //Oracle,Sql Server, Postgres,MongoDb
            _products = new List<Product>
            {
                new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
                new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
                new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
                new Product{ProductId=5,CategoryId=2,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            // _products.Remove(product); //Silme işlemi yapmaz. Çünkü listedeki elemanlarla aynı referans numarasına sahip olması lazım.
            //Linq kullanılmasaydı eşleştirmeyi döngüler yardımıyla yapardık.
            Product productToDelete = null;

            /*foreach (var p in _products)
            {
                if (product.ProductId == p.ProductId)
                {
                    productToDelete = p;
                }
            }*/

            //LINQ - Language Integrated Query
            //Lambda

            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            // ID olan aramalarda SingleOrDefault(x => x.Id == y.Id) metodu kullanılır. 
            //First()
             _products.Remove(productToDelete);
            
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetByAllCategory(int categoryId)
        {
            //İçindeki şarta uyan bütün elemanları yeni bir liste haline getirir.
            return _products.Where(p=>p.CategoryId ==categoryId).ToList();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName=product.ProductName;
            productToUpdate.CategoryId=product.CategoryId;
            productToUpdate.UnitPrice=product.UnitPrice;
            productToUpdate.UnitsInStock=product.UnitsInStock;

        }
    }
}