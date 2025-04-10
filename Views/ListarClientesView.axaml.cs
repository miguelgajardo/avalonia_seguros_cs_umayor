// Views/ListarClientesView.axaml.cs
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MyAvaloniaApp.Views
{
    public partial class ListarClientesView : UserControl
    {
        public ListarClientesView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}