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
            _logger.LogWarning("Game not found with id {Id}", id);
            throw new KeyNotFoundException($"Game not found with id {id}");
        }

        return game;
    }

    public void Save(BlackJackGame game)
    {
        _games[game.ID] = game;
        _logger.LogInformation("Game saved with id {Id}", game.ID);
    }
}
