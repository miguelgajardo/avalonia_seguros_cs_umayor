using Avalonia.Controls;
using System;
using System.Threading.Tasks;

namespace MyAvaloniaApp.Services
{
    public class DialogService : IDialogService
    {
        private readonly Func<Window> _windowGetter;

        public DialogService(Func<Window> windowGetter)
        {
            _windowGetter = windowGetter;
        }

        public async Task ShowMessageAsync(string title, string message)
        {
            var owner = _windowGetter();
            if (owner == null)
            {
                Console.WriteLine("⚠️ La ventana principal no se encuentra disponible.");
                return;
            }

            var dialog = new Window
            {
                Title = title,
                Content = new TextBlock { Text = message },
                SizeToContent = SizeToContent.WidthAndHeight,
                Width = 300
            };

            await dialog.ShowDialog(owner);
        }

    }
}