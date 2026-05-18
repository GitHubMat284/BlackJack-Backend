using Blackjack.Application.Models;
using Blackjack.Application.UseCases;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BlackJack_Backend;

public class PlayerStandFunction
{
    private readonly ILogger<PlayerStandFunction> _logger;
    private readonly PlayerStand _playerStandInteractor;

    public PlayerStandFunction(ILogger<PlayerStandFunction> logger, PlayerStand playerStandInteractor) {
        _logger = logger;
        _playerStandInteractor = playerStandInteractor;
    }

    [Function("PlayerStand")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
    {
        var request = await req.ReadFromJsonAsync<GameRequest>();
        _logger.LogInformation("PlayerHit request received: {@Request}", request);

        if (request == null || string.IsNullOrEmpty(request.GameID))
        {
            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        var result = _playerStandInteractor.Run(request);
        _logger.LogInformation("PlayerHit response: {@Response}", result);

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(result);

        return response;
    }
}