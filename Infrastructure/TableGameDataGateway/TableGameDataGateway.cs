using Azure;
using Azure.Data.Tables;
using Blackjack.Application.Interfaces;
using BlackJack.Domain.Entities;
using System.Text.Json;

namespace Infrastructure.TableGameDataGateway;

/// <summary>
/// Represents a table entity for storing game-related data in Azure Table Storage.
/// </summary>
/// <remarks>This class implements the ITableEntity interface, enabling integration with Azure Table Storage
/// operations. The PartitionKey is set to "game" by default to group all game entities together. The RowKey uniquely
/// identifies each game entity within the partition. The Data property holds the serialized game data. Timestamp and
/// ETag are used for concurrency and tracking changes.</remarks>
public class TableGameEntity : ITableEntity
{
    public string PartitionKey { get; set; } = "game";
    public string RowKey { get; set; } = default!;
    public string Data { get; set; } = default!;

    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
}
public class TableGameDataGateway : IGameDataGateway
{
    private readonly TableClient _table;

    public TableGameDataGateway(TableClient table)
    {
        _table = table;
    }

    public void Delete(string gameID)
    {
        throw new NotImplementedException();
    }

    public BlackJackGame GetByID(string id)
    {
        var entity = _table.GetEntity<TableGameEntity>("game", id);

        return JsonSerializer.Deserialize<BlackJackGame>(entity.Value.Data)!;
    }

    public void Save(BlackJackGame game)
    {
        var entity = new TableGameEntity
        {
            RowKey = game.ID,
            Data = JsonSerializer.Serialize(game)
        };

        _table.UpsertEntity(entity);
    }
}
