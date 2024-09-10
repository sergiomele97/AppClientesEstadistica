namespace BackendEstadistica.Servicios;

public class DivisaRepositorio
{
    private readonly HttpClient _httpClient;

    private readonly ContextoBBDD _contextBBDD;
    private readonly IEstadisticasRepositorio _estadisticasRepositorio;
    public DivisaRepositorio(HttpClient httpClient, ContextoBBDD contextBBDD, IEstadisticasRepositorio estadisticasRepositorio)
    {
        _httpClient = httpClient;
        _estadisticasRepositorio = estadisticasRepositorio;
        _contextBBDD = contextBBDD;
    }

    public async Task PoblarMonedas()
    {
        try
        {
            var response = await _httpClient.GetStringAsync("https://v6.exchangerate-api.com/v6/a52cae132e4ab45938d6219f/latest/USD");
            var exchangeRateResponse = JsonConvert.DeserializeObject<ExchangeRateResponse>(response);

            if (exchangeRateResponse == null || exchangeRateResponse.ConversionRates == null || !exchangeRateResponse.ConversionRates.Any())
            {
                throw new Exception("No se pudo obtener las tasas de cambio o las tasas están vacías.");
            }

            DateTime fechaRecogida = DateTime.Parse(exchangeRateResponse.TimeLastUpdateUtc);

            var divisas = exchangeRateResponse.ConversionRates.Select(rate => new Divisa
            {
                Nombre = rate.Key,
                Valor = rate.Value,
                Fecha = fechaRecogida,
            }).ToList();

            _contextBBDD.Divisa.AddRange(divisas);
            await _contextBBDD.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            // Manejo de errores apropiado
            throw new Exception($"Error al poblar monedas: {ex.Message}", ex);
        }
    }


    public class ExchangeRateResponse
    {

        [JsonProperty("base_code")]
        public string? BaseCode { get; set; }

        [JsonProperty("conversion_rates")]
        public Dictionary<string, double>? ConversionRates { get; set; }

        [JsonProperty("time_last_update_utc")]
        public string? TimeLastUpdateUtc { get; set; }
    }

}
