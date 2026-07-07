namespace SampleApp.Core.Todos;

public sealed record TodoItem(Guid Id, string Title, bool IsDone)
{
    public static TodoItem Create(string title) => new(Guid.NewGuid(), title, IsDone: false);

    public TodoItem MarkDone() => this with { IsDone = true };
}
