using SportsStore.Model.Abstract;
using SportsStore.Model.Entities;
using SportsStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository _repository;
        private readonly IOrderProcessor _orderProcessor;

        public CartController(IProductRepository repo, IOrderProcessor proc)
        {
            _repository = repo;
            _orderProcessor = proc;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста");
            }

            if (ModelState.IsValid)
            {
                _orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();

                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public Product FindSize(Product product, string size)
        {
            foreach (var find in product.SizeMass)
            {
                if (find == size)
                {
                    return product;
                }
            }

            return null;
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl, string size)
        {      
            Product product = _repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (FindSize(product,size) != null)
            {
                cart.AddItem(product, 1, size);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = _repository.Products
                .FirstOrDefault(p => p.ProductID == productId);

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }
    }
}