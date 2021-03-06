﻿using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using System.Configuration;
using MvcApp1.Models;
using MvcApp1.Infrastructure.Abstract;
using MvcApp1.Infrastructure.Concrete;

namespace MvcApp1.Infrastructure
{

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {            
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}