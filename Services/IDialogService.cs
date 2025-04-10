//Interfaz para el uso de boxes de diálogo en la app
using System.Threading.Tasks;

public interface IDialogService
{
    Task ShowMessageAsync(string title, string message);
}
