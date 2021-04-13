using Ninject;
using SportsStore.Model.Abstract;
using SportsStore.Model.Concrete;
using SportsStore.Model.Entities;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            { 
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID).Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Where(p => category == null || p.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

        public ViewResult ProductView(int id = 1)
        {
            Product product = repository.Products.Where(p => p.ProductID == id).FirstOrDefault();           
            return View(product);
        }
    }
}
