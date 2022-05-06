using Ninject;
using SportsStore.Infrastructure.Concrete;
using SportsStore.Model.Abstract;
using SportsStore.Model.Concrete;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportsStore.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;

        public NinjectControllerFactory()
        {
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null 
                ? null 
                : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            _ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();

            SettingsUser emailSettings = new SettingsUser();

            _ninjectKernel.Bind<IOrderProcessor>()
                .To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);
            _ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}