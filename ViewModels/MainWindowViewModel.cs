using ReactiveUI;
using System;
using System.Reactive;

namespace MyAvaloniaApp.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private new readonly IDialogService _dialogService;
        private ViewModelBase _vistaActual = null!;
        
        public ViewModelBase VistaActual
        {
            get => _vistaActual;
            set => this.RaiseAndSetIfChanged(ref _vistaActual, value);
        }
        public ReactiveCommand<Unit, Unit> MostrarAgregarClienteCommand { get; }
        public ReactiveCommand<Unit, Unit> MostrarListarClientesCommand { get; }
        // public ReactiveCommand<Unit, Unit> MostrarAgregarPolizaCommand { get; }
        public ReactiveCommand<Unit, Unit> MostrarSimularAdquisicionCommand { get; }
        // public ReactiveCommand<Unit, Unit> MostrarConsultarPolizasCommand { get; }
        public ReactiveCommand<Unit, Unit> SalirCommand { get; }

        public MainWindowViewModel(IDialogService dialogService) : base(dialogService)
        {
            _dialogService = dialogService;

            MostrarAgregarClienteCommand = ReactiveCommand.Create(() => 
            {
                Console.WriteLine("AgregarClienteViewModel");
                VistaActual = new AgregarClienteViewModel(_dialogService);
                Console.WriteLine($"VistaActual: {VistaActual?.GetType().Name}");
            });
            
            MostrarListarClientesCommand = ReactiveCommand.Create(() =>
            {
                Console.WriteLine("ListarClientesViewModel");
                VistaActual = new ListarClientesViewModel(_dialogService);
            });
        
            MostrarSimularAdquisicionCommand = ReactiveCommand.Create(() =>
            {
                Console.WriteLine("SimularAdquisicionViewModel");
                VistaActual = new SimularAdquisicionViewModel(_dialogService);
            });
            
            SalirCommand = ReactiveCommand.Create(() =>
            {
                Console.WriteLine("Saliendo de la App");
                Environment.Exit(0);
            });
            //Inicializa la vista por defecto
            VistaActual = new ListarClientesViewModel(_dialogService);
        }
    }
}