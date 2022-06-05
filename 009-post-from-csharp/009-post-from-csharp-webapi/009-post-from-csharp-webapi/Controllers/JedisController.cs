using Microsoft.AspNetCore.Mvc;
using Starwars.Core.Entities;

namespace _009_post_from_csharp_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JedisController : ControllerBase
    {
        private static readonly string[] JEDIS = new[]
        {
            "Yoda", "Mace Windu", "Qui-Gon Jinn", "Obi-Wan Kenobi", "Anakin Skywalker", "Ahsoka Tano", "Mace Windu"
        };

        private readonly ILogger<JedisController> _logger;

        public JedisController(ILogger<JedisController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "Search")]
        //public IResult Search(JediFilter jediFilter) but is not easy to test IResult
        public IEnumerable<string> Search(JediFilter jediFilter)
        {
            if (jediFilter == null)
            {
                return null; //Results.BadRequest();
            }

            var query = from j in JEDIS
                        where j.Contains(jediFilter.TextToSearch, StringComparison.InvariantCultureIgnoreCase)
                        select j;

            return query.ToArray(); //Results.Ok(query.ToArray());
        }
    }
}