using Blackjack.Application.Models;
using Blackjack.Application.UseCases;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BlackJack_Backend.Functions;

public class PlayerHitFunction
{
    private readonly ILogger<PlayerHitFunction> _logger;
    private readonly PlayerHit _playerHitInteractor;

    public PlayerHitFunction(ILogger<PlayerHitFunction> logger, PlayerHit playerHitInteractor) {
        _logger = logger;
        _playerHitInteractor = playerHitInteractor;
    }

    [Function("PlayerHit")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
    {
        var request = await req.ReadFromJsonAsync<GameRequest>();
        _logger.LogInformation("PlayerHit request received: {@Request}", request);
     
        if(request == null)
        {
            return req.CreateResponse(HttpStatusCode.BadRequest);
        }

        var result = _playerHitInteractor.Run(request);
        _logger.LogInformation("PlayerHit response: {@Response}", result);

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(result);

        return response;
    }
}