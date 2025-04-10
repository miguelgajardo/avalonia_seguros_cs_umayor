//Clase estática para el control de datos
using System.Collections.Generic;
using MyAvaloniaApp.Models;

public static class DatosSistema
{
    public static List<Cliente> ListaClientes { get; set; } = 
        new List<Cliente>
        {
            new Cliente
            {
                Rut = "12.345.678-9",
                Nombre = "Juan",
                Apellido = "Pérez",
                Telefono = "+56912345678"
            },
            new Cliente
            {
                Rut = "7.765.432-1",
                Nombre = "María",
                Apellido = "Gómez",
                Telefono = "+56987654321"
            }
        };
    
    public static decimal ValorUFEnPesos { get; set; } = 36000;
}