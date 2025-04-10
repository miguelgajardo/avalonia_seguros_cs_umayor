using System;
using System.Reactive;
using System.Threading.Tasks;
using MyAvaloniaApp.Models;
using ReactiveUI;

namespace MyAvaloniaApp.ViewModels
{
    public class AgregarClienteViewModel : ViewModelBase
    {
        private string _nombre = string.Empty;
        public string Nombre
        {
            get => _nombre;
            set => this.RaiseAndSetIfChanged(ref _nombre, value);
        }

        private string _rut = string.Empty;
        public string Rut
        {
            get => _rut;
            set => this.RaiseAndSetIfChanged(ref _rut, value);
        }

        private string _direccion = string.Empty;
        public string Direccion
        {
            get => _direccion;
            set => this.RaiseAndSetIfChanged(ref _direccion, value);
        }

        private string _telefono = string.Empty;
        public string Telefono
        {
            get => _telefono;
            set => this.RaiseAndSetIfChanged(ref _telefono, value);
        }
        public ReactiveCommand<Unit, Unit> GuardarClienteCommand { get; }

        public AgregarClienteViewModel(IDialogService dialogService) : base(dialogService)
        {
            var canSave = this.WhenAnyValue(
                x => x.Nombre,
                x => x.Rut,
                (nombre, rut) => 
                    !string.IsNullOrWhiteSpace(nombre) && 
                    !string.IsNullOrWhiteSpace(rut));

            GuardarClienteCommand = ReactiveCommand.CreateFromTask(GuardarCliente, canSave);
        }

        private async Task GuardarCliente()
        {
            try
            {
                var nuevoCliente = new Cliente
                {
                    Nombre = Nombre,
                    Rut = Rut,
                    Telefono = Telefono
                };

                DatosSistema.ListaClientes.Add(nuevoCliente);
                await _dialogService.ShowMessageAsync("Éxito", 
                    $"Cliente {Nombre} guardado correctamente\n" +
                    $"RUT: {Rut}\n" +
                    $"Dirección: {Direccion}\n" +
                    $"Teléfono: {Telefono}");
                Nombre = string.Empty;
                Rut = string.Empty;
                Direccion = string.Empty;
                Telefono = string.Empty;
            }
            catch (Exception ex)
            {
                await _dialogService.ShowMessageAsync("Error", 
                    $"Error al guardar cliente: {ex.Message}");
            }
        }
    }
}