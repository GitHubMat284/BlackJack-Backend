/// <summary>
/// Represents the input data required to act (hit/stand) on a running Blackjack game
/// processed by the Application layer.
/// </summary>
/// <remarks>
/// This request model is defined in the Application layer to establish
/// a stable communication contract without exposing Domain Entities directly.
/// </remarks>
namespace Blackjack.Application.Models;
public class GameRequest
{
    public required string GameID { get; set; }
}