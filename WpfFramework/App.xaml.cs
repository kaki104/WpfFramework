using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WpfFramework.Controls;
using WpfFramework.Models;
using WpfFramework.Services;
using WpfFramework.ViewModels;

namespace WpfFramework
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();
            InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public static new App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            ServiceCollection services = new();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //ViewModel 등록
            _ = services.AddTransient(typeof(MainViewModel));
            _ = services.AddTransient(typeof(HomeViewModel));
            _ = services.AddTransient(typeof(CustomerViewModel));
            _ = services.AddTransient(typeof(LoginPageViewModel));

            //Control 등록
            _ = services.AddTransient(typeof(AboutControl));

            //AppContext 싱글톤 등록
            _ = services.AddSingleton<IAppContext, Models.AppContext>();
            //IDatabaseService 싱글톤 등록
            _ = services.AddSingleton<IDatabaseService, SqlService>(obj => new SqlService(connectionString));

            return services.BuildServiceProvider();
        }
    }
}
