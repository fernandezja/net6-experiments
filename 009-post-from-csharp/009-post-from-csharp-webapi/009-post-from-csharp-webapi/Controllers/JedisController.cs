using Microsoft.AspNetCore.Mvc;
using Starwars.Core.Entities;

namespace _009_post_from_csharp_webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JedisController : ControllerBase
    {
        private static readonly List<Jedi> JEDIS = new()
        {
            new Jedi(1, "Yoda"),
            new Jedi(2, "Mace Windu"),
            new Jedi(3, "Qui-Gon Jinn"),
            new Jedi(4, "Obi-Wan Kenobi"),
            new Jedi(5, "Anakin Skywalker"),
            new Jedi(6, "Ahsoka Tano"),
            new Jedi(7, "Mace Windu")
        };



        private readonly ILogger<JedisController> _logger;

        public JedisController(ILogger<JedisController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("search")]
        //public IResult Search(JediFilter jediFilter) but is not easy to test IResult
        public IEnumerable<Jedi> Search(JediFilter jediFilter)
        {
            if (jediFilter == null)
            {
                return null; //Results.BadRequest();
            }

            var query = from j in JEDIS
                        where j.Name.Contains(jediFilter.TextToSearch, StringComparison.InvariantCultureIgnoreCase)
                        select j;


            return query.ToList(); //Results.Ok(query.ToArray());
        }


        [HttpPost]
        [Route("SearchWithHttpHeaders")]
        //public IResult Search(JediFilter jediFilter) but is not easy to test IResult
        public IEnumerable<Jedi> SearchWithHttpHeaders(JediFilter jediFilter)
        {
            if (jediFilter == null)
            {
                return null; //Results.BadRequest();
            }

            var jedis = new List<Jedi>();
            var index = 1;

            foreach (var header in Request.Headers)
            {
                jedis.Add(new Jedi() { 
                    JediId = index++,
                    Name = $"Header > {header.Key}={header.Value}"
                });
            }

            var query = from j in jedis
                        where j.Name.Contains(jediFilter.TextToSearch, StringComparison.InvariantCultureIgnoreCase)
                        select j;


            return query.ToArray(); //Results.Ok(query.ToArray());
        }
    }
}