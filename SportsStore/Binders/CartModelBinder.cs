using SportsStore.Model.Entities;
using System.Web.Mvc;

namespace SportsStore.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string _sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Cart cart = (Cart)controllerContext.HttpContext.Session[_sessionKey];

            if (cart == null)
            {
                cart = new Cart();

                controllerContext.HttpContext.Session[_sessionKey] = cart;
            }
         
            return cart;
        }
    }
}