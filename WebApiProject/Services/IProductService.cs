using WebApiProject.Entities;

namespace WebApiProject.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(int top=0);
        Product? GetProductById(int productId);
        Product Add(Product product);
        Product Update(Product product);
        void Delete(int id);
    }
}
