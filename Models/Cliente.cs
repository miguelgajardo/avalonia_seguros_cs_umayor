//Clase cliente para operaciones con póliza y CRUD Cliente
using System.Collections.Generic;

namespace MyAvaloniaApp.Models
{
    public class Cliente
    {
        public string? Rut { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Telefono { get; set; }
          public List<Poliza> Polizas { get; set; } = new List<Poliza>();
}
}