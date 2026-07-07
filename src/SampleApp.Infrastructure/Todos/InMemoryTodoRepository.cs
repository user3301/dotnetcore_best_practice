using System.Collections.Concurrent;
using SampleApp.Core.Todos;

namespace SampleApp.Infrastructure.Todos;

/// <summary>
/// In-memory stand-in for a real data store. In a production app this is where
/// EF Core, Dapper, or an external service client would live.
/// </summary>
public sealed class InMemoryTodoRepository : ITodoRepository
{
    private readonly ConcurrentDictionary<Guid, TodoItem> _items = new();

    public Task<TodoItem?> GetAsync(Guid id, CancellationToken cancellationToken = default) =>
        Task.FromResult(_items.TryGetValue(id, out var item) ? item : null);

    public Task<IReadOnlyList<TodoItem>> ListAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult<IReadOnlyList<TodoItem>>([.. _items.Values]);

    public Task SaveAsync(TodoItem item, CancellationToken cancellationToken = default)
    {
        _items[item.Id] = item;
        return Task.CompletedTask;
    }
}
