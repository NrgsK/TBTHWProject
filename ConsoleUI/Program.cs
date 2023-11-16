using Bussiness.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

internal class Program
{
    // sOlid
    // Open Closed Principle : Yeni bir özellik ekliyorsan mevcuttaki hiçbir koda dokunamazsın.
    private static void Main(string[] args)
    {
        ProductTest();

        //DTO : Data Transformation Object
        //IoC container
        //productManager.GetAll()
        //productManager.GetAllByCategoryId(id)

        //CategoryTest();

    }

    private static void CategoryTest()
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        foreach (var category in categoryManager.GetAll())
        {
            Console.WriteLine(category.CategoryName);
        }
    }

    private static void ProductTest()
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        foreach (var product in productManager.GetProductDetails())
        {
            Console.WriteLine(product.ProductName + "/" + product.CategoryName);
        }
    }
}