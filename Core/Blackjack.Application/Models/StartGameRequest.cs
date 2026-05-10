namespace Blackjack.Application.Models;
/// <summary>
/// Represents the input data required to start a new Blackjack game in the 
/// Application layer.
/// </summary>
/// <remarks>
/// This request model is defined in the application layer to establish
/// a stable communication contract without exposing Domain Entities directly.
/// </remarks>
public class StartGameRequest
{
    public string? PlayerName { get; set; }
}
