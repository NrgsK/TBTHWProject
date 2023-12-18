using Bussiness.Abstract;
using Bussiness.BusinessAspects.Autofac;
using Bussiness.CCS;
using Bussiness.Constants;
using Bussiness.ValidationRules.FluentValidation;
using Core.Aspects.AutoFac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        ICategoryService _categoryService;
        // !!! bir entitymanager kendisi hariç başka bir dal'ı enjekte edemez. Servis çağırabiliriz.
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            //Constructor
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //[LogAspect] -->AOP
        //[Validate],[Cache],[RemoveCache],[Transaction],[Performance]
        //AOP : Uygulama hata verdiğinde çalıştırmak istediğin kodlar varsa bu yapıyı kullanırsın. 
        //Intenception - araya girme

        //Claim
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //iş kurallarını tekrarlı olmaamasına dikkat et. tekrarlı yapı çirkin koddur.

            //aynı isimde ürün eklenemez
            //kategory sınırı 
            //eğer mevcut kategori sayısı 15'i geçtiyse yeni ürün eklenemez.
            IResult result =  BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), 
                CheckIfProductNameExists(product.ProductName),CheckIfCategoryLimitExceded());

            if (result!= null)
            {
                return result;
            }


            return new ErrorResult();
            //business codes
            //validation 

            //Cross Cutting Concerns - Log, Cache, Transaction
            //ValidationTool.Validate(new ProductValidator(),product); //bir iş kuralı değil

        }

        public IDataResult<List<Product>> GetAll()
        {
            // İş kodları
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());

        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count();

            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            throw new NotImplementedException();
        }

        //private olmasının sebebi metodun sadece bu sınıf içerisinde kullanılması istendiği için.
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            // parametre olarak Product product gönderilmesi de uygundur fakat int category daha efektif 

            // select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count();

            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();

        }

        private IResult CheckIfProductNameExists(string productName)
        {
            // Aynı isimde ürün eklenemez
            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); //aynı kayıt var mı system.linq

            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();

        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

    }
}
