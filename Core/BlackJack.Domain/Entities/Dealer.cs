namespace BlackJack.Domain.Entities;
/// <summary>
/// Represents a dealer containing a hand of cards and decision method to hit or not.
/// </summary>
public class Dealer
{
    public Hand Hand { get; } = new();

    /// <summary>
    /// Decision method to hit or not, currently set to hit anything lower than 17 points
    /// </summary>
    public bool ShouldHit() => Hand.GetHandValue() < 17;
}