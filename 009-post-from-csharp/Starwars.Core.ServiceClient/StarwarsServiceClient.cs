using Starwars.Core.Entities;
using System.Text;
using System.Text.Json;

namespace Starwars.Core.ServiceClient
{
    public class StarwarsServiceClient
    {
        private const string CONTENTTYPE_APPLICATION_JSON = "application/json";
        private const string DEFAULT_BASEADDRESS = "https://localhost:7067";
        private const string API_JEDI_SEARCH_URL = "/jedis/search";
        private const string API_JEDI_SEARCH_WITHHTTPHEADERS_URL = "/jedis/searchWithHttpHeaders";

        public Uri BaseAddress { get; set; } = new Uri(DEFAULT_BASEADDRESS);


        public StarwarsServiceClient()
        {
        }

        
        public async Task<IEnumerable<Jedi>> SearchAsync(JediFilter jediFilter, 
                                                      CancellationToken cancellationToken = default)
        {

            var httpClient = HttpClientFactory.Create();
            httpClient.BaseAddress = BaseAddress;

            //Add Custom Hader
            httpClient.DefaultRequestHeaders
                  .Add("X-CustomHeader-1", "kAw4dhLDTHY8HvEZWZmv7k6/PHw=");

            httpClient.DefaultRequestHeaders
                  .Add("X-CustomHeader-2", "0123456789-abcdefghijklmnoprrstuvwxyz");


            var dataJson = JsonSerializer.Serialize(jediFilter);
            
            var data = new StringContent(dataJson, Encoding.UTF8, CONTENTTYPE_APPLICATION_JSON);
            
            var responseMessage = await httpClient.PostAsync(API_JEDI_SEARCH_URL,
                                                                data,
                                                                cancellationToken);



            
            if (responseMessage.IsSuccessStatusCode)
            {
                var stream = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<IEnumerable<Jedi>>(stream);
            }
            
            return null;
        }



        public async Task<IEnumerable<Jedi>> SearchAsync(string textToSearch,
                                                      CancellationToken cancellationToken = default)
        {

            var jediFilter = new JediFilter()
            {
                TextToSearch = textToSearch
            };
            
            return await SearchAsync(jediFilter);
        }


        public async Task<IEnumerable<Jedi>> SearchUseSendAsync(JediFilter jediFilter,
                                                      CancellationToken cancellationToken = default)
        {

            var httpClient = HttpClientFactory.Create();
            httpClient.BaseAddress = BaseAddress;


            var dataJson = JsonSerializer.Serialize(jediFilter);

            var data = new StringContent(dataJson, Encoding.UTF8, CONTENTTYPE_APPLICATION_JSON);


            var requestUri = new Uri(string.Concat(DEFAULT_BASEADDRESS, API_JEDI_SEARCH_URL));

            var request = new HttpRequestMessage(HttpMethod.Post, 
                                                 requestUri: requestUri)
            { 
                Content = data
            };

            //Add Custom Hader
            request.Headers
                  .Add("X-CustomHeader-1", "kAw4dhLDTHY8HvEZWZmv7k6/PHw=");

            request.Headers
                  .Add("X-CustomHeader-2", "0123456789-abcdefghijklmnoprrstuvwxyz");



            var responseMessage = await httpClient.SendAsync(request,
                                                                cancellationToken);




            if (responseMessage.IsSuccessStatusCode)
            {
                var stream = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<IEnumerable<Jedi>>(stream);
            }

            return null;
        }


        public async Task<IEnumerable<Jedi>> SearchWithHttpHeadersUseSendAsync(JediFilter jediFilter,
                                                     CancellationToken cancellationToken = default)
        {

            var httpClient = HttpClientFactory.Create();
            httpClient.BaseAddress = BaseAddress;


            var dataJson = JsonSerializer.Serialize(jediFilter);

            var data = new StringContent(dataJson, Encoding.UTF8, CONTENTTYPE_APPLICATION_JSON);


            var requestUri = new Uri(string.Concat(DEFAULT_BASEADDRESS, API_JEDI_SEARCH_WITHHTTPHEADERS_URL));

            var request = new HttpRequestMessage(HttpMethod.Post,
                                                 requestUri: requestUri)
            {
                Content = data
            };

            //Add Custom Hader
            request.Headers
                  .Add("X-CustomHeader-1", "kAw4dhLDTHY8HvEZWZmv7k6/PHw=");

            request.Headers
                  .Add("X-CustomHeader-2", "0123456789-abcdefghijklmnoprrstuvwxyz");



            var responseMessage = await httpClient.SendAsync(request,
                                                                cancellationToken);




            if (responseMessage.IsSuccessStatusCode)
            {
                var stream = await responseMessage.Content.ReadAsStringAsync(cancellationToken);
                return JsonSerializer.Deserialize<IEnumerable<Jedi>>(stream);
            }

            return null;
        }


    }
}