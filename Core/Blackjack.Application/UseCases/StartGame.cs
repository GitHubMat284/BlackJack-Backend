using Blackjack.Application.Interfaces;
using BlackJack.Domain.Entities;

namespace Blackjack.Application.UseCases;
public class StartGame
{
    private readonly IDataGateway _dataGateway;

    public StartGame(IDataGateway dataGateway) => _dataGateway = dataGateway;

    public GameStateResponse Run()
    {
        var game = new BlackJackGame();

        _dataGateway.Save(game);

        return GameStateResponse.MapGameToDTO(game);
    }
}
