using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using Ninject;
using Ninject.Syntax;
using Ninject.Activation;
using Ninject.Parameters;
using ShoesStore.App_Start;

namespace ShoesStore.Repository
{
    public class NinjectDependencyResolver : NinjectScope, IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            _kernel = kernel;
            AddBindings();
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }

        private void AddBindings()
        {
            _kernel.Bind<IProductRepository>().To<ProductRepository>();
        }
    }

    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot root;

        public NinjectScope(IResolutionRoot kernel)
        {
            root = kernel;
        }

        public object GetService(Type serviceType)
        {
            IRequest request = root.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return root.Resolve(request).SingleOrDefault();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = root.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return root.Resolve(request).ToList();
        }

        public void Dispose()
        {
            IDisposable disposable = (IDisposable)root;
            if (disposable != null) disposable.Dispose();
            root = null;
        }
    }
}