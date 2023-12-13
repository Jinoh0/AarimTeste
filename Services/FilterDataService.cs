using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AARIMTESTE.Services
{
    public class FilterDataService
    {
        private readonly HttpClient _client;

        public FilterDataService()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetCharacterDataAsync(string apiUrl)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    Console.WriteLine("Falha ao tentar trazer as informações.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao fazer a requisição: {ex.Message}");
            }
            return string.Empty;
        }
    }
}