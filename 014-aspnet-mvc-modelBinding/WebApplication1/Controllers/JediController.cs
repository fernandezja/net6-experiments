using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers
{
    public class JediController : Controller
    {
        private readonly ILogger<JediController> _logger;

        public JediController(ILogger<JediController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new List<Jedi>());

        }

        [HttpPost]
        public IActionResult Index([FromBody] List<Jedi> jedis)
        {
            if (!ModelState.IsValid)
            {
                //var errorMessage = string.Join(" | ", ModelState.Values
                //               .SelectMany(v => v.Errors)
                //               .Select(e => e.ErrorMessage));
                //return BadRequest(errorMessage);

                return BadRequest(ModelState.AllErrors());
            }

            return View(jedis);
        }

        [HttpPost]
        public IActionResult DemoValueCountLimit([FromBody] Jedi jedi1, 
                                                 [FromBody] Jedi jedi2, 
                                                 [FromBody] Jedi jedi3,
                                                 [FromBody] Jedi jedi4)
        {
            var jedis = new List<Jedi>();
            jedis.Add(jedi1);
            jedis.Add(jedi2);
            jedis.Add(jedi3);
            jedis.Add(jedi4);
    

            return View("Index", jedis);
        }


    }
}