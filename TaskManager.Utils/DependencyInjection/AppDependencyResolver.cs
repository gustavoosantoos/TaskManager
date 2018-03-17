using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Utils.DependencyInjection
{
    public class AppDependencyResolver
    {
        private static AppDependencyResolver _resolver;

        public static AppDependencyResolver Current => _resolver;


        public static void Init(IServiceProvider services)
        {
            _resolver = new AppDependencyResolver(services);
        }

        private readonly IServiceProvider _serviceProvider;

        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public T GetService<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }

        private AppDependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
