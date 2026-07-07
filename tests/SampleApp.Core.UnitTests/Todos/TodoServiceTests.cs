using SampleApp.Core.Todos;

namespace SampleApp.Core.UnitTests.Todos;

public class TodoServiceTests
{
    private readonly FakeTodoRepository _repository = new();
    private readonly TodoService _service;

    public TodoServiceTests()
    {
        _service = new TodoService(_repository);
    }

    [Fact]
    public async Task AddAsync_WithValidTitle_SavesTrimmedItem()
    {
        var item = await _service.AddAsync("  Buy milk  ");

        Assert.Equal("Buy milk", item.Title);
        Assert.False(item.IsDone);
        Assert.Same(item, Assert.Single(await _repository.ListAsync()));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public async Task AddAsync_WithBlankTitle_Throws(string title)
    {
        await Assert.ThrowsAsync<ArgumentException>(() => _service.AddAsync(title));
    }

    [Fact]
    public async Task AddAsync_WithOverlongTitle_Throws()
    {
        var title = new string('x', TodoService.MaxTitleLength + 1);

        await Assert.ThrowsAsync<ArgumentException>(() => _service.AddAsync(title));
    }

    [Fact]
    public async Task CompleteAsync_WithExistingItem_MarksItDone()
    {
        var item = await _service.AddAsync("Buy milk");

        var completed = await _service.CompleteAsync(item.Id);

        Assert.NotNull(completed);
        Assert.True(completed.IsDone);
    }

    [Fact]
    public async Task CompleteAsync_WithUnknownId_ReturnsNull()
    {
        var completed = await _service.CompleteAsync(Guid.NewGuid());

        Assert.Null(completed);
    }

    /// <summary>
    /// A tiny hand-rolled fake. For richer scenarios a mocking library
    /// (NSubstitute, Moq) is the usual choice; a fake keeps this example
    /// dependency-free.
    /// </summary>
    private sealed class FakeTodoRepository : ITodoRepository
    {
        private readonly Dictionary<Guid, TodoItem> _items = [];

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
}
