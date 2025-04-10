using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public static class UfService
{
    public static async Task<decimal> ObtenerValorUfActual()
    {
        try
        {
            Console.WriteLine("Obteniendo valor UF...");

            using var client = new HttpClient();
            var response = await client.GetStringAsync("https://api.sbif.cl/api/uf?apikey=TU_API_KEY&formato=json");

            var ufData = JsonConvert.DeserializeObject<UfResponse>(response);

            return ufData?.Valor ?? 36000;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener valor UF: {ex.Message}");
            return DatosSistema.ValorUFEnPesos;
        }
    }

    public class UfResponse
    {
        public decimal Valor { get; set; }
    }
}