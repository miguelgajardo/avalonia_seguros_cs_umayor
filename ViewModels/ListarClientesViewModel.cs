using MyAvaloniaApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyAvaloniaApp.ViewModels
{
    public class ListarClientesViewModel : ViewModelBase
    {
        private ObservableCollection<Cliente> _clientes = new();
        
        public IEnumerable<Cliente> Clientes => _clientes;
        
        public ListarClientesViewModel(IDialogService dialogService) : base(dialogService)
        {
            // _clientes.Add(new Cliente { 
            //     Nombre = "Juan Pérez", 
            //     Rut = "12.345.678-9",
            //     Apellido = "Pérez",
            //     Telefono = "+56912345678"
            // });
        CargarClientesDesdeDatosSistema();
        }

         private void CargarClientesDesdeDatosSistema()
        {
            _clientes.Clear();
            foreach (var cliente in DatosSistema.ListaClientes)
                _clientes.Add(cliente);
        }
    }
}