using _002_webapi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _002_webapi.Controllers;
[ApiController]
[Route("[controller]")]
public class CommentsController : ControllerBase
{
    
    private readonly ILogger<WeatherForecastController> _logger;

    public CommentsController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result = new ContentResult()
        {
            Content = "Comments OK",
            ContentType = "text/plain"
        };

        return result;
    }

    [HttpPut]
    [Route("/comments/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommentDTO))]
    [ProducesResponseType(StatusCodes.Status403Forbidden)] 
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, CommentDTO commentDTO)
    {
        if (commentDTO == null)
            return BadRequest();


        if (commentDTO.UserId <= 0) {
            //return Forbid();
            return StatusCode(StatusCodes.Status403Forbidden);
        }
           

        if (ModelState.IsValid)
        {
            return new OkObjectResult(commentDTO);
        }

        return NotFound();
    }
}
