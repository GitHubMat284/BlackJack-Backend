namespace BlackJack.Domain.Entities;

/// <summary>
/// Represents a player containing a hand of cards.
/// </summary>
public class Player
{
    public Hand Hand { get; } = new();
}