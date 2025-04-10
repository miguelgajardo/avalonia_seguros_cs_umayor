using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reactive;
using ReactiveUI;
using MyAvaloniaApp.Models;
using System;

namespace MyAvaloniaApp.ViewModels
{
    public class SimularAdquisicionViewModel : ViewModelBase
    {
        private Cliente? _clienteSeleccionado;

        public Cliente? ClienteSeleccionado
        {
            get => _clienteSeleccionado;
            set => this.RaiseAndSetIfChanged(ref _clienteSeleccionado, value);
        }

        // Listar los clientes - dropdown - para asociar la póliza
        public List<Cliente> Clientes => DatosSistema.ListaClientes;

        // Nueva póliza para completar
        private Poliza _nuevaPoliza = new Poliza();
        public Poliza NuevaPoliza
        {
            get => _nuevaPoliza;
            set => this.RaiseAndSetIfChanged(ref _nuevaPoliza, value);
        }

        public decimal ValorUfEnPesos { get; private set; }
        public decimal ValorTotalPesos => NuevaPoliza.PrimaUF * ValorUfEnPesos;

        public ReactiveCommand<Unit, Unit> CargarValorUfCommand { get; }
        public ReactiveCommand<Unit, Unit> GuardarPolizaCommand { get; }

        public SimularAdquisicionViewModel(IDialogService dialogService) : base(dialogService)
        {
            CargarValorUf();
            // Carga valor UF
            CargarValorUfCommand = ReactiveCommand.CreateFromTask(CargarValorUf);

            // Guarda la póliza
            GuardarPolizaCommand = ReactiveCommand.CreateFromTask(GuardarPoliza);
        }

        // Carga valor UF desde servicio
        private async Task CargarValorUf()
        {
            ValorUfEnPesos = await UfService.ObtenerValorUfActual();
            Console.WriteLine($"Valor UF: {ValorUfEnPesos}");   
            this.RaisePropertyChanged(nameof(ValorUfEnPesos));
            this.RaisePropertyChanged(nameof(ValorTotalPesos));
            await _dialogService.ShowMessageAsync("Información", $"Valor UF actualizado: {ValorUfEnPesos:C}");
        }

        // Guarda póliza
        private async Task GuardarPoliza()
        {
            if (ClienteSeleccionado == null)
            {
                await _dialogService.ShowMessageAsync("Error", "Debe seleccionar un cliente");
                return;
            }

            if (NuevaPoliza.PrimaUF <= 0)
            {
                await _dialogService.ShowMessageAsync("Error", "Valor de la Prima debe ser positivo");
                return;
            }

            // Asignar la póliza al cliente seleccionado
            NuevaPoliza.Cliente = ClienteSeleccionado;
            ClienteSeleccionado.Polizas.Add(NuevaPoliza);

            // Reset NuevaPoliza after adding it to the client
            NuevaPoliza = new Poliza();

            // Notify the view to update the UI
            this.RaisePropertyChanged(nameof(NuevaPoliza));

            await _dialogService.ShowMessageAsync("Éxito", "Póliza asociada al cliente exitosamente");
        }
    }
}
