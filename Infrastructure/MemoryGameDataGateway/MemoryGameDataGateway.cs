using Blackjack.Application.Interfaces;
using BlackJack.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Infrastructure.MemoryGameData;

/// <summary>
/// Provides an in-memory implementation of the IGameDataGateway interface for storing and retrieving BlackJackGame
/// instances.
/// </summary>
/// <remarks>This class is used with no persistent storage. All game data saved may act as volatile. This
/// implementation is considered for testing only during early application development.</remarks>
public class MemoryGameDataGateway : IGameDataGateway
{
    private static readonly ConcurrentDictionary<string, BlackJackGame> _games = new();
    private readonly ILogger<MemoryGameDataGateway> _logger;

    public MemoryGameDataGateway(ILogger<MemoryGameDataGateway> logger)
    {
        _logger = logger;
    }

    public BlackJackGame GetByID(string id)
    {
        _logger.LogInformation("Games in memory: {Count}", _games.Count);

        if (!_games.TryGetValue(id, out var game))
        {
            _logger.LogWarning("Game not found with id {ID}", id);
            throw new KeyNotFoundException($"Game not found with id: {id}");
        }

        return game;
    }

    public void Save(BlackJackGame game)
    {
        _games[game.ID] = game;
        _logger.LogInformation("Game saved with id {ID}", game.ID);
    }

    public void Delete(String gameID)
    {
        if(_games.TryRemove(gameID, out _))
        {
            _logger.LogInformation("Successfully deleted game with id: {ID}", gameID);
        } else
        {
            _logger.LogWarning("Attempted to delete missing game with id: {ID}", gameID);
        }
    }
}
