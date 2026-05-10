namespace BlackJack.Domain.Entities;

public enum Suit
{
    Clubs,
    Spades,
    Hearts,
    Diamonds
}

public enum Rank
{
    Two = 2, // Enum auto-increments until Ten
    Three,
    Four,
    Five,
    Six,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
}

/// <summary>
/// Domain entitiy representing a playing card, with a Suit and Rank
/// </summary>
public class Card
{
    public readonly Suit Suit;
    public readonly Rank Rank;

    public Card(Suit suit, Rank rank) {         
        Suit = suit;
        Rank = rank;
    }

    /// <summary>
    /// Returns actual card value with no adjustments 
    /// </summary>
    public int GetValue()
    {
        if (Rank >= Rank.Two && Rank <= Rank.Ten)
            return (int)Rank;
        else if (Rank >= Rank.Jack && Rank <= Rank.King)
            return 10;
        else // Ace returns 11, adjusted to 1 as necessary in Hand core business logic
            return 11;
    }
}