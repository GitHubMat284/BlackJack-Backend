using Blackjack.Application.DTO;
using Blackjack.Application.Interfaces;

namespace Blackjack.Application.UseCases
{
    public class PlayerHit
    {
        private readonly IDataGateway _dataGateway;

        public PlayerHit(IDataGateway dataGateway) => _dataGateway = dataGateway;

        public GameStateResponse Run(GameRequest request)
        {
            var game = _dataGateway.GetByID(request.GameID);

            game.PlayerHit();

            _dataGateway.Save(game);

            return GameStateResponse.MapGameToDTO(game);
        }
    }
}
