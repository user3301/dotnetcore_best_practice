namespace SampleApp.Core.Todos;

/// <summary>
/// Abstraction owned by the Core layer; Infrastructure provides the implementation.
/// This keeps the dependency arrow pointing inwards (Api -> Infrastructure -> Core).
/// </summary>
public interface ITodoRepository
{
    Task<TodoItem?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<TodoItem>> ListAsync(CancellationToken cancellationToken = default);

    Task SaveAsync(TodoItem item, CancellationToken cancellationToken = default);
}
