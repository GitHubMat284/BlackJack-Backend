using BlackJack.Domain.Entities;

namespace Blackjack.Application.Interfaces;

/// <summary>
/// Defines methods for retrieving and saving game data in a persistent storage system.
/// </summary>
public interface IGameDataGateway
{
    /// <summary>
    /// Retrieves the BlackJackGame instance with the specified identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the BlackJackGame to retrieve. Cannot be null or empty.</param>
    /// <returns>The BlackJackGame instance that matches the specified identifier, or null if no such game exists.</returns>
    BlackJackGame GetByID(string id);

    /// <summary>
    /// Saves the specified BlackJack game state to persistent storage.
    /// </summary>
    /// <param name="game">The BlackJackGame instance representing the current game state to save. Cannot be null.</param>
    void Save(BlackJackGame game);

    /// <summary>
    /// Deletes a completed BlackJack game from persistance storage
    /// </summary>
    /// <param name="gameID">Unique Game ID Hash to be deleted</param>
    void Delete(String gameID);
}
