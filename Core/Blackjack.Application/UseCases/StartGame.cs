using Blackjack.Application.Interfaces;
using Blackjack.Application.Models;
using BlackJack.Domain.Entities;

namespace Blackjack.Application.UseCases;
/// <summary>
/// Executes the start game action to run a new BlackJack game.
/// Request: StartGameRequest class
/// Response: GameStateResponse class
/// </summary>
public class StartGame
{
    private readonly IGameDataGateway _dataGateway;

    public StartGame(IGameDataGateway dataGateway) => _dataGateway = dataGateway;

    public GameStateResponse Run(StartGameRequest startGameRequest)
    {
        var game = new BlackJackGame(startGameRequest.PlayerName ?? "Player");

        _dataGateway.Save(game);

        return GameStateResponse.MapGameToDTO(game);
    }
}
