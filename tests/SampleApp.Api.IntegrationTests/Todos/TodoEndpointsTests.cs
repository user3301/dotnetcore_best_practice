using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using SampleApp.Core.Todos;

namespace SampleApp.Api.IntegrationTests.Todos;

/// <summary>
/// Integration tests boot the real app in-process with WebApplicationFactory
/// and exercise it over HTTP, so routing, DI, and serialization are all covered.
/// </summary>
public class TodoEndpointsTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public TodoEndpointsTests(WebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task PostTodo_ThenList_ReturnsCreatedItem()
    {
        var createResponse = await _client.PostAsJsonAsync("/todos", new { Title = "Write integration tests" });

        Assert.Equal(HttpStatusCode.Created, createResponse.StatusCode);
        var created = await createResponse.Content.ReadFromJsonAsync<TodoItem>();
        Assert.NotNull(created);
        Assert.Equal("Write integration tests", created.Title);

        var items = await _client.GetFromJsonAsync<List<TodoItem>>("/todos");
        Assert.NotNull(items);
        Assert.Contains(items, i => i.Id == created.Id);
    }

    [Fact]
    public async Task PostTodo_WithBlankTitle_ReturnsBadRequest()
    {
        var response = await _client.PostAsJsonAsync("/todos", new { Title = "" });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CompleteTodo_WithUnknownId_ReturnsNotFound()
    {
        var response = await _client.PostAsync($"/todos/{Guid.NewGuid()}/complete", content: null);

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
