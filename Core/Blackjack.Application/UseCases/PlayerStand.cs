using Blackjack.Application.Models;
using Blackjack.Application.Interfaces;

namespace Blackjack.Application.UseCases;
public class PlayerStand
{
    private readonly IGameDataGateway _dataGateway;

    public PlayerStand(IGameDataGateway dataGateway) => _dataGateway = dataGateway;

    public GameStateResponse Run(GameRequest request)
    {
        var game = _dataGateway.GetByID(request.GameID);

        game.PlayerStand();

        _dataGateway.Save(game);

        return GameStateResponse.MapGameToDTO(game);
    }
}
