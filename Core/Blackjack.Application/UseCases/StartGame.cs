using Blackjack.Application.Interfaces;
using Blackjack.Application.Models;
using BlackJack.Domain.Entities;

namespace Blackjack.Application.UseCases;
public class StartGame
{
    private readonly IGameDataGateway _dataGateway;

    public StartGame(IGameDataGateway dataGateway) => _dataGateway = dataGateway;

    public GameStateResponse Run()
    {
        var game = new BlackJackGame();

        _dataGateway.Save(game);

        return GameStateResponse.MapGameToDTO(game);
    }
}
