using Starwars.Core.Entities;
using System.Linq;

namespace Starwars.Core.ServiceClient.Tests
{
    public class StarwarsServiceClientTest
    {
        [Fact]
        public async Task SearchAsync_Test()
        {
            var client = new StarwarsServiceClient();

            var jediFilter = new JediFilter() {
                TextToSearch = "y"
            };

            var result = await client.SearchAsync(jediFilter);

            Assert.NotNull(result);

            var jedis = result.ToList();
            
            Assert.Equal(2, jedis.Count());
            Assert.Equal("Yoda", jedis[0].Name);
            Assert.Equal("Anakin Skywalker", jedis[1].Name);


        }


        [Fact]
        public async Task SearchUseSendAsync_Test()
        {
            var client = new StarwarsServiceClient();

            var jediFilter = new JediFilter()
            {
                TextToSearch = "y"
            };

            var result = await client.SearchUseSendAsync(jediFilter);

            Assert.NotNull(result);

            var jedis = result.ToList();

            Assert.Equal(2, jedis.Count());
            Assert.Equal("Yoda", jedis[0].Name);
            Assert.Equal("Anakin Skywalker", jedis[1].Name);


        }


        [Fact]
        public async Task SearchWithHttpHeadersUseSendAsync_Test()
        {
            var client = new StarwarsServiceClient();

            var jediFilter = new JediFilter()
            {
                TextToSearch = "X-CustomHeader"
            };

            var result = await client.SearchWithHttpHeadersUseSendAsync(jediFilter);

            Assert.NotNull(result);

            var jedis = result.ToList();

            Assert.Equal(2, jedis.Count());
            Assert.Equal("Header > X-CustomHeader-1=kAw4dhLDTHY8HvEZWZmv7k6/PHw=", jedis[0].Name);
            Assert.Equal("Header > X-CustomHeader-2=0123456789-abcdefghijklmnoprrstuvwxyz", jedis[1].Name);


        }


        [Fact]
        public async Task SearchWithHttpHeadersUseSendAsync_VerifyAuthorizationHeader_Test()
        {
            var client = new StarwarsServiceClient();

            var jediFilter = new JediFilter()
            {
                TextToSearch = "Authorization"
            };

            var result = await client.SearchWithHttpHeadersUseSendAsync(jediFilter);

            Assert.NotNull(result);

            var jedis = result.ToList();

            Assert.Single(jedis);
            Assert.Equal("Header > Authorization=Basic kAw4dhLDTHY8HvEZWZmv7k6/PHw=", jedis[0].Name);

        }


        [Fact]
        public async Task SearchUseSendCCreateHttpRequestMessageAsync_VerifyCustomHeader_Test()
        {
            var client = new StarwarsServiceClient();

            var jediFilter = new JediFilter()
            {
                TextToSearch = "Content"
            };

            var result = await client.SearchUseSendCCreateHttpRequestMessageAsync(jediFilter);

            Assert.NotNull(result);

            var jedis = result.ToList();

            Assert.Equal(2, jedis.Count());
            Assert.Equal("Header > X-CustomHeader-1=kAw4dhLDTHY8HvEZWZmv7k6/PHw=", jedis[0].Name);
            Assert.Equal("Header > X-CustomHeader-2=0123456789-abcdefghijklmnoprrstuvwxyz", jedis[1].Name);

        }


        
    }
}