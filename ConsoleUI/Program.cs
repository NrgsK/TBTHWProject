using Bussiness.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

internal class Program
{
    // sOlid
    // Open Closed Principle : Yeni bir özellik ekliyorsan mevcuttaki hiçbir koda dokunamazsın.
    private static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new EfProductDal());

        foreach (var product in productManager.GetAllByUnitPrice(10, 100))
        {
            Console.WriteLine(product.ProductName);
        }
        //productManager.GetAll()
        //productManager.GetAllByCategoryId(id)



        Console.ReadKey();
    }
}