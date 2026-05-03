using BlackJack.Domain.Entities;

namespace Blackjack.Application.Models;
public class GameStateResponse
{
    public required string GameID { get; set; }
    public required string Status { get; set; }
    public IEnumerable<string> PlayerCards { get; set; } = Enumerable.Empty<string>();
    public IEnumerable<string> DealerCards { get; set; } = Enumerable.Empty<string>();


    public static GameStateResponse MapGameToDTO(BlackJackGame game) => new()
    {
        GameID = game.ID,
        PlayerCards = game.Player.Hand.Cards.Select(c => c.ToString() ?? string.Empty),
        DealerCards = game.Dealer.Hand.Cards.Select(c => c.ToString() ?? string.Empty),
        Status = game.Status.ToString()
    };
}