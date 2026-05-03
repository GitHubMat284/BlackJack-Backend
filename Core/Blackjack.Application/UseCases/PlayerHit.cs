using Blackjack.Application.Models;
using Blackjack.Application.Interfaces;

namespace Blackjack.Application.UseCases
{
    public class PlayerHit
    {
        private readonly IGameDataGateway _dataGateway;

        public PlayerHit(IGameDataGateway dataGateway) => _dataGateway = dataGateway;

        public GameStateResponse Run(GameRequest request)
        {
            var game = _dataGateway.GetByID(request.GameID);

            game.PlayerHit();

            _dataGateway.Save(game);

            return GameStateResponse.MapGameToDTO(game);
        }
    }
}
