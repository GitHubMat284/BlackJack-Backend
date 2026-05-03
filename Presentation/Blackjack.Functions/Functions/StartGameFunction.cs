using Blackjack.Application.Models;
using Blackjack.Application.UseCases;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace BlackJack_Backend;

public class StartGameFunction
{
    private readonly ILogger<StartGameFunction> _logger;
    private readonly StartGame _startGameInteractor;

    public StartGameFunction(ILogger<StartGameFunction> logger, StartGame playerHitInteractor) {
        _logger = logger;
        _startGameInteractor = playerHitInteractor;
    }

    [Function("StartGame")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
    {
        var request = await req.ReadFromJsonAsync<StartGameRequest>();

        _logger.LogInformation("StartGame request received: {@Request}", request);

        var result = _startGameInteractor.Run();

        _logger.LogInformation("StartGame response: {@Response}", result);

        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(result);

        return response;
    }
}