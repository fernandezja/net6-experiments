using Starwars.Core.Entities;
using System.Text;
using System.Text.Json;

namespace Starwars.Core.ServiceClient
{
    public class StarwarsServiceClient
    {
        private const string CONTENTTYPE_APPLICATION_JSON = "application/json";
        
        private readonly HttpClient _httpClient;

        public StarwarsServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        
        public async Task<IEnumerable<string>> SearchAsync(JediFilter jediFilter, 
                                                      CancellationToken cancellationToken = default)
        {
            
            var dataJson = JsonSerializer.Serialize(jediFilter);
            
            var data = new StringContent(dataJson, Encoding.UTF8, CONTENTTYPE_APPLICATION_JSON);
            
            var responseMessage = await _httpClient.PostAsync("/api/jedis/search",
                                                                data,
                                                                cancellationToken);
            
            if (responseMessage.IsSuccessStatusCode)
            {
                var stream = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<IEnumerable<string>>(stream);
            }
            
            return null;
        }


        public async Task<IEnumerable<string>> SearchAsync(string textToSearch,
                                                      CancellationToken cancellationToken = default)
        {

            var jediFilter = new JediFilter()
            {
                TextToSearch = textToSearch
            };
            
            return await SearchAsync(jediFilter);
        }



    }
}