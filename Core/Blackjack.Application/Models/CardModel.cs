namespace Blackjack.Application.Models;

public class CardModel
{
    public string Suit { get; set; } = default!;
    public string Rank { get; set; } = default!;
    public int Value { get; set; }
}