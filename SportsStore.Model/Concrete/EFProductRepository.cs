using SportsStore.Model.Abstract;
using SportsStore.Model.Entities;
using System.Linq;

namespace SportsStore.Model.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext _context = new EFDbContext();

        public IQueryable<Product> Products
        {
            get 
            { 
                return _context.Products; 
            }
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = _context.Products
                .Find(productID);

            if (dbEntry != null)
            {
                _context.Products.Remove(dbEntry);
                _context.SaveChanges();
            }

            return dbEntry;
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                _context.Products.Add(product);
            }
            else
            {
                Product dbEntry = _context.Products
                    .Find(product.ProductID);

                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Firma = product.Firma;
                    dbEntry.Size = product.Size;
                    dbEntry.Category = product.Category;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }
            }

            _context.SaveChanges();
        }
    }
}
