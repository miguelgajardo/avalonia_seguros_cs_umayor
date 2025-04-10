using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace MyAvaloniaApp.Views
{
    public partial class SimularAdquisicionView : UserControl
    {
        public SimularAdquisicionView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
