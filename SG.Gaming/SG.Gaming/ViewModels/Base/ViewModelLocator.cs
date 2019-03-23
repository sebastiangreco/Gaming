using Autofac;
using SG.Gaming.Services;
using SG.Gaming.Services.User;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace SG.Gaming.ViewModels
{
    public static class ViewModelLocator
    {
        #region properties
        private static IContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);
        #endregion

        #region Public properties
        public static bool UseMockService { get; set; }
        #endregion

        #region Public methods
        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        public static void RegisterDependencies(bool useMockServices)
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<RootViewModel>();
            builder.RegisterType<MenuViewModel>();
            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<SampleViewModel>();

            //Services
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<RequestProvider>().As<IRequestProvider>();
            builder.RegisterType<UserService>().As<IUserService>();

            //General
            builder.RegisterType<GamingApp>().As<IGamingApp>().SingleInstance();

            if (_container != null)
            {
                _container.Dispose();
            }
            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
        #endregion

        #region Private methods
        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
        #endregion
    }
}
