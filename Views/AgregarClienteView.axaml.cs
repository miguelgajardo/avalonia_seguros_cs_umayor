// Views/AgregarClienteView.axaml.cs
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MyAvaloniaApp.Views
{
    public partial class AgregarClienteView : UserControl
    {
        public AgregarClienteView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}