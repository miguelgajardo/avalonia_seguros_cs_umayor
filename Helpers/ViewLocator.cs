using Avalonia.Controls;
using Avalonia.Controls.Templates;
using MyAvaloniaApp.ViewModels;
using System;

namespace MyAvaloniaApp.Helpers
{
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? data)
        {
            if (data is null)
                return null;

            var name = data.GetType().FullName?.Replace("ViewModel", "View");
            if (name is null)
                return new TextBlock { Text = "ViewModel Inválido" };

            var type = Type.GetType(name);
            if (type is null)
                return new TextBlock { Text = $"Vista no encontrada: {name}" };

            return Activator.CreateInstance(type) as Control;
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
