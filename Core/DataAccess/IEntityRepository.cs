using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
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
//Core katmanı diğer katmanları referans ALMAZ!!!