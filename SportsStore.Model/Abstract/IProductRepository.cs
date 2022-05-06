using SportsStore.Model.Entities;
using System.Linq;

namespace SportsStore.Model.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        void SaveProduct(Product product);

        void AddProduct(Product product);

        Product DeleteProduct(int productID);
    }
}
