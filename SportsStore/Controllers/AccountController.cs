using SportsStore.Infrastructure.Concrete;
using SportsStore.Models;
using System.Web.Mvc;

namespace SportsStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthProvider _authProvider;

        public AccountController(IAuthProvider auth)
        {
            _authProvider = auth;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_authProvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {    
                    ModelState.AddModelError("", "Введите корректный логин или пароль");

                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}