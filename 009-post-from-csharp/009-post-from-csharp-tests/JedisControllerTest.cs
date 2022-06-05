using _009_post_from_csharp_webapi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Starwars.Core.Entities;
using System.Text;
using System.Text.Json;

namespace _009_post_from_csharp_tests
{
    public class JedisControllerTest
    {
        private const string CONTENTTYPE_APPLICATION_JSON = "application/json";

        private Mock<ILogger<JedisController>> _mockJediLogger;

        public JedisControllerTest()
        {
            _mockJediLogger = new Mock<ILogger<JedisController>>();
        }

        
        [Fact]
        public void Search_Via_Controller_Direct()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["X-Example"] = "test-header";
            
            var jediController = new JedisController(_mockJediLogger.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = httpContext
                }
            };

            var jediFilter = new JediFilter()
            {
                TextToSearch = "y"
            };

            var result = jediController.Search(jediFilter);

            Assert.NotNull(result);
            Assert.IsType<string[]>(result);

            var jedis = (string[])result;
            Assert.Equal(2, jedis.Count());
            Assert.Equal("Yoda", jedis[0]);
            Assert.Equal("Anakin Skywalker", jedis[1]);



        }



        [Fact]
        public async Task Search_Via_WebApplication()
        {
            await using var app = new StarwarsWebApiApplication();


            var jediFilter = new JediFilter()
            {
                TextToSearch = "y"
            };

            var dataJson = JsonSerializer.Serialize(jediFilter);

            var data = new StringContent(dataJson, Encoding.UTF8, CONTENTTYPE_APPLICATION_JSON);


            var client = app.CreateClient();

            var responseMessage = await client.PostAsync("/jedis", content: data);


            Assert.True(responseMessage.IsSuccessStatusCode);

            var stream = await responseMessage.Content.ReadAsStringAsync();
            var jedis = JsonSerializer.Deserialize<string[]>(stream);

            Assert.Equal(2, jedis.Count());
            Assert.Equal("Yoda", jedis[0]);
            Assert.Equal("Anakin Skywalker", jedis[1]);



        }
    }
}