using Ninject;
using SportsStore.Model.Abstract;
using SportsStore.Model.Entities;
using SportsStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IKernel _ninjectKernel;
        private readonly int _pageSize = 6;
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public ViewResult List(string search, string category, int page = 1)
        {
            ViewBag.ValueSearch = search;   
            
            ProductsListViewModel model = new ProductsListViewModel
            { 
                Products = _repository.Products
                .Where(p => category == null || p.Category == category)
                .Where(p=> search == null || p.Name.Contains(search) || p.Category.Contains(search))
                .OrderBy(p => p.ProductID).Skip((page - 1) * _pageSize)
                .Take(_pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = _pageSize,
                    TotalItems = _repository.Products
                    .Where(p => category == null || p.Category == category)
                    .Where(p => search == null || p.Name.Contains(search) || p.Category.Contains(search))
                    .Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = _repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ViewResult ProductView(int id = 1)
        {
            Product product = _repository.Products
                .Where(p => p.ProductID == id)
                .FirstOrDefault();   
            
            return View(product);
        }
    }
}
