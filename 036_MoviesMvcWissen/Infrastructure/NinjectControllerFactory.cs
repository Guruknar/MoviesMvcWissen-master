using _036_MoviesMvcWissen.Models.LogDemo;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _036_MoviesMvcWissen.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel();
            //_kernel.Bind<ILogger>().To<DatabaseLogger>().InSingletonScope(); // tek sefer new liyor
            //_kernel.Bind<ILogger>().To<DatabaseLogger>().InTransientScope(); // her seferinde newliyor
            //_kernel.Bind<ILogger>().To<DatabaseLogger>().InThreadScope(); // her client için new liyor
            _kernel.Bind<ILogger>().To<FileLogger>().InThreadScope(); // databaselogger değil filelogger kullanmak için

        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }

    }
}