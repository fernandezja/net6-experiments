using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;

namespace _003_websocket_server.Controllers;
[ApiController]
[Route("[controller]")]
public class WebsocketController : ControllerBase
{   
    private readonly ILogger<WebsocketController> _logger;

    public WebsocketController(ILogger<WebsocketController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/echo")]
    public async Task EchoEvent()
    {
        if (HttpContext.WebSockets.IsWebSocketRequest)
        {
            using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
            _logger.Log(LogLevel.Information, "WebSocket connection established");
            await EchoEventAction(webSocket);
        }
        else
        {
            HttpContext.Response.StatusCode = 400;
        }
    }


    private async Task EchoEventAction(WebSocket webSocket)
    {
        var buffer = new byte[1024 * 4];
        var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
        _logger.Log(LogLevel.Information, "Message received from Client");

        while (!result.CloseStatus.HasValue)
        {
            var message = Encoding.UTF8.GetBytes($"Ping {DateTime.Now.ToString("ddd yyyy-MM-dd HH:mm:ss.FFF")}");

            await webSocket.SendAsync(new ArraySegment<byte>(message, 0, message.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
            _logger.Log(LogLevel.Information, "Message sent to Client");

            result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            _logger.Log(LogLevel.Information, "Message received from Client");

        }

        await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        _logger.Log(LogLevel.Information, "WebSocket connection closed");
    }

}
