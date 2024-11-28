using Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TestSamtelNET.Domain.Services;
using TestSamtelNET.Infraestructure.Entities;
using TestSamtelNET.Infraestructure.Interfaces;

namespace SamtelNetTest
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        // Configuración de inyección de dependencias
        private void ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            // Registrar MainWindow para la inyección de dependencias
            serviceCollection.AddScoped<MainWindow>();
            // Configuración de EF Core
            serviceCollection.AddDbContext<SamtelContext>(options =>
                options.UseSqlServer("Server=DESKTOP-0SDTHPP\\SQLEXPRESS;Database=TestSamtelNET;Trusted_Connection=True;TrustServerCertificate=true;"));

            // Registrar servicios
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
            serviceCollection.AddScoped<IAreaRepository, AreaRepository>();
            serviceCollection.AddScoped<UserService>();
            serviceCollection.AddScoped<AreaService>();


            // Construir el ServiceProvider
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        // Configuración de inicio de la aplicación
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Configurar los servicios antes de iniciar la aplicación
            ConfigureServices();

            // Obtener la instancia de MainWindow del contenedor de dependencias
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();

            // Mostrar la ventana
            mainWindow.Show();
        }
    }
}
