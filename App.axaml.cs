using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MyAvaloniaApp.Services;
using MyAvaloniaApp.ViewModels;
using MyAvaloniaApp.Views;

namespace MyAvaloniaApp
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }
        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
                var dialogService = new DialogService(() => desktop.MainWindow);
                desktop.MainWindow.DataContext = new MainWindowViewModel(dialogService);
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}