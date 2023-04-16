using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebApplication1.Controllers;

namespace WebApplication1.Tests
{
    public class JediControllerTests
    {
        [Fact]
        public void IndexPost_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
           
            var mockLogger = new Mock<ILogger<JediController>>();
            var controller = new JediController(mockLogger.Object);
            controller.ModelState.AddModelError("The jedis field is required", "Required");
            controller.ModelState.AddModelError("'.' is an invalid start of a value. Path: $[3]", "Required");

            var result = controller.Index(new List<Entities.Jedi>());

            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<System.String>(badRequestResult.Value);
        }
    }
}