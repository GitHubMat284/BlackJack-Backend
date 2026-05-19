using Blackjack.Application.Models;
using Blackjack.Application.Interfaces;

namespace Blackjack.Application.UseCases;

/// <summary>
/// Executes the player stand action for a running BlackJack game.
/// Request: GameRequest class
/// Response: GameStateResponse class
/// </summary>
public class PlayerStand
{
    private readonly IGameDataGateway _dataGateway;

    public PlayerStand(IGameDataGateway dataGateway) => _dataGateway = dataGateway;

    public GameStateResponse Run(GameRequest request)
    {
        var game = _dataGateway.GetByID(request.GameID);

        game.PlayerStand();

        _dataGateway.Delete(game.ID);

        return GameStateResponse.MapGameToDTO(game);
    }
}
