using Avalonia;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyAvaloniaApp.Services;
using MyAvaloniaApp.ViewModels;
using MyAvaloniaApp.Views;
using System;

namespace MyAvaloniaApp
{
    public sealed class Program
    {
        public static IServiceProvider? Services { get; private set; }

        [STAThread]
        public static void Main(string[] args)
        {
            // First build the Avalonia app
            var appBuilder = BuildAvaloniaApp();

            // Configure DI container
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    // Register services with deferred window resolution
                    services.AddSingleton<IDialogService>(provider => 
                        new DialogService(() => 
                            (provider.GetService<MainWindow>() ?? throw new InvalidOperationException("MainWindow not found"))));
                    
                    // Register view models
                    services.AddTransient<MainWindowViewModel>();
                    services.AddTransient<AgregarClienteViewModel>();
                    services.AddTransient<ListarClientesViewModel>();
                })
                .Build();

            Services = host.Services;

            // Start application and create window in the callback
            appBuilder.StartWithClassicDesktopLifetime(args, ShutdownMode.OnMainWindowClose);
        }

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace()
                .UseReactiveUI();
    }
}