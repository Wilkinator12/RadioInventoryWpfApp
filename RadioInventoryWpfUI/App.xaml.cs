using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RadioInventoryWpfUI.ViewModels;
using RadioInventoryWpfUI.Views;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace RadioInventoryWpfUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider GlobalServiceProvider = null!;
        public static IMapper Mapper = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();


            var services = new ServiceCollection();
            services.AddTransient<MainWindow>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<ViewRadiosView>();
            services.AddTransient<ViewRadiosViewModel>();
            services.AddTransient<CreateRadiosView>();
            services.AddTransient<CreateRadiosViewModel>();
            services.AddAutoMapper(typeof(App));
            services.AddRadioInventoryServices();
            services.AddSingleton(config);
            GlobalServiceProvider = services.BuildServiceProvider();
            Mapper = GlobalServiceProvider.GetService<IMapper>()!;


            GlobalServiceProvider.GetService<MainWindow>()!.Show();
        }
    }

}
