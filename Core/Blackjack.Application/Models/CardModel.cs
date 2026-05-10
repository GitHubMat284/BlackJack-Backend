namespace Blackjack.Application.Models;

/// <summary>
/// Defines a simplified card data model exposed by the Application layer.
/// </summary>
/// <remarks>
/// This model is used for transferring card information across application
/// boundaries without exposing domain entities directly.
/// </remarks>
public class CardModel
{
    public string Suit { get; set; } = default!;
    public string Rank { get; set; } = default!;
    public int Value { get; set; }
}