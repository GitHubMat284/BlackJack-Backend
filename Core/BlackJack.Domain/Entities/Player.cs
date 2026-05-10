namespace BlackJack.Domain.Entities;

/// <summary>
/// Represents a player containing player name and a hand of cards.
/// </summary>
public class Player
{
    public string Name { get; }

    public Hand Hand { get; } = new();
    
    public Player(string? name)
    {
        Name = String.IsNullOrEmpty(name) ? "Player" : name;
    }
}