using Blackjack.Application.Interfaces;
using BlackJack.Domain.Entities;
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
    private readonly ConcurrentDictionary<string, BlackJackGame> _games = new();

    public BlackJackGame GetByID(string id)
    {
        if (_games.TryGetValue(id, out var game))
            throw new KeyNotFoundException($"Game not found with id {id}");
       
        return game!;
    }

    public void Save(BlackJackGame game)
    {
        _games[game.ID] = game;
    }
}
