using Autofac;
using System;

namespace Xamarin.Summit
{
    public class ViewModelLocator
    {
        IContainer _container;
        ContainerBuilder _containerBuilder;

        static readonly ViewModelLocator _instance = new ViewModelLocator();
        public static ViewModelLocator Instance => _instance;

        public ViewModelLocator()
            => _containerBuilder = new ContainerBuilder();

        public T Resolve<T>()
            => _container.Resolve<T>();

        public object Resolve(Type type)
            => _container.Resolve(type);

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
            => _containerBuilder.RegisterType<TImplementation>().As<TInterface>();

        public void Register<T>() where T : class
            => _containerBuilder.RegisterType<T>();

        public void Build()
        {
            if (_container == null)
                _container = _containerBuilder.Build();
        }
    }
}
