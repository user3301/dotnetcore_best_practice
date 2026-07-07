namespace SampleApp.Core.Todos;

public sealed class TodoService(ITodoRepository repository)
{
    public const int MaxTitleLength = 200;

    public async Task<TodoItem> AddAsync(string title, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title must not be empty.", nameof(title));
        }

        if (title.Length > MaxTitleLength)
        {
            throw new ArgumentException($"Title must be at most {MaxTitleLength} characters.", nameof(title));
        }

        var item = TodoItem.Create(title.Trim());
        await repository.SaveAsync(item, cancellationToken);
        return item;
    }

    public async Task<TodoItem?> CompleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await repository.GetAsync(id, cancellationToken);
        if (item is null)
        {
            return null;
        }

        var completed = item.MarkDone();
        await repository.SaveAsync(completed, cancellationToken);
        return completed;
    }

    public Task<IReadOnlyList<TodoItem>> ListAsync(CancellationToken cancellationToken = default) =>
        repository.ListAsync(cancellationToken);
}
