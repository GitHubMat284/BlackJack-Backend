using Blackjack.Application.DTO;
using Blackjack.Application.Interfaces;

namespace Blackjack.Application.UseCases;
public class PlayerStand
{
    private readonly IDataGateway _dataGateway;

    public PlayerStand(IDataGateway dataGateway) => _dataGateway = dataGateway;

    public GameStateResponse Run(GameRequest request)
    {
        var game = _dataGateway.GetByID(request.GameID);

        game.PlayerStand();

        _dataGateway.Save(game);

        return GameStateResponse.MapGameToDTO(game);
    }
}
