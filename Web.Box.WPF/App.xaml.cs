using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Web.Box.Features.Services;
using Web.Box.WPF.Core;
using Web.Box.WPF.MVVM.ViewModels;
using Web.Box.WPF.Services;

namespace Web.Box.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

            /// view model registration (can be done using reflection)
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<SettingsViewModel>();
            services.AddSingleton<GuidGeneratorViewModel>();

            // navigation registration
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<Func<Type, ViewModel>>(provider => viewModelType => (ViewModel)provider.GetRequiredService(viewModelType));

            // service registration
            services.AddTransient<IGuidGeneratorService, GuidGeneratorService>();
            services.AddTransient<IGuidFormatterService, GuidFormatterService>();
            services.AddSingleton<IThemePickerService, ThemePickerService>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}