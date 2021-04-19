using Ninject;
using SportsStore.Model.Abstract;
using SportsStore.Model.Concrete;
using SportsStore.Model.Entities;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        public IKernel ninjectKernel;
        public int PageSize = 6;
        public IProductRepository repository;


        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string search, string category, int page = 1)
        {
            ViewBag.ValueSearch = search;          
            ProductsListViewModel model = new ProductsListViewModel
            { 
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .Where(p=> search == null || p.Name.Contains(search) || p.Category.Contains(search))
                .OrderBy(p => p.ProductID).Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Where(p => category == null || p.Category == category)
                    .Where(p => search == null || p.Name.Contains(search) || p.Category.Contains(search)).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
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
            Product product = repository.Products.Where(p => p.ProductID == id).FirstOrDefault();           
            return View(product);
        }

    }
}
