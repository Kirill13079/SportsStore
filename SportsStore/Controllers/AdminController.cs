using SportsStore.Model.Abstract;
using SportsStore.Model.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductRepository _repository;

        public AdminController(IProductRepository repo)
        {
            _repository = repo;
        }

        public ViewResult Index()
        {
            return View(_repository.Products);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageData = new byte[image.ContentLength];
                    product.ImageMimeType = image.ContentType;

                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }

                _repository.AddProduct(product);

                TempData["message"] = string.Format("{0} добавлен", product.Name);

                return RedirectToAction("Index");
            }
            else return View(product);
        }

        public ViewResult Edit(int productId)
        {
            Product product = _repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageData = new byte[image.ContentLength];
                    product.ImageMimeType = image.ContentType;

                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }

                _repository.SaveProduct(product);

                TempData["message"] = string.Format("{0} сохранен", product.Name);

                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = _repository.DeleteProduct(productId);

            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} удален", deletedProduct.Name);
            }

            return RedirectToAction("Index");
        }
    }
}