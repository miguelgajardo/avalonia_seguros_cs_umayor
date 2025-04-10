using ReactiveUI;

namespace MyAvaloniaApp.ViewModels
{
    public class ViewModelBase : ReactiveObject
    {
        protected readonly IDialogService _dialogService;
        public ViewModelBase(IDialogService dialogService)
        {
        _dialogService = dialogService;
        }
    }
}