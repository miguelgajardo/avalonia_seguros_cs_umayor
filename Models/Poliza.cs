//Clase Poliza para operaciones con póliza y CRUD Poliza
namespace MyAvaloniaApp.Models {
public class Poliza
{
    public int Codigo { get; set; }
    public string? Tipo { get; set; }
    public int Vigencia { get; set; }
    public decimal PrimaUF { get; set; }
    public Cliente? Cliente { get; set; }
}
}
