using BlackJack.Domain.Entities;

namespace Blackjack.Application.Models;
public class GameStateResponse
{
    public required string GameID { get; set; }
    public required string Status { get; set; }
    public IEnumerable<CardModel> PlayerCards { get; set; } = Enumerable.Empty<CardModel>();
    public IEnumerable<CardModel> DealerCards { get; set; } = Enumerable.Empty<CardModel>();


    public static GameStateResponse MapGameToDTO(BlackJackGame game) => new()
    {
        GameID = game.ID,
        Status = game.Status.ToString(),
        PlayerCards = game.Player.Hand.Cards.Select(ToModel).ToList(),
        DealerCards = game.Dealer.Hand.Cards.Select(ToModel).ToList()
    };

    private static CardModel ToModel(Card c) => new()
    {
        Suit = c.Suit.ToString(),
        Rank = c.Rank.ToString(),
        Value = c.GetValue()
    };
}