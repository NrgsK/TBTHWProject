using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //Generic constraint - kısıt
    //class : referans tip
    //IEntity: IEntity olabilir veta IEntity implemente eden bir nesne olabilir
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter); //Tek bir kaydı getirmek için
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //List<T> GetByAllCategory(int categoryId);  //Ürünleri kategoriye göre listeler
        //Expression<Func<T, bool>> filter = null -- Filtreleme yapar. Delege
    }
}
