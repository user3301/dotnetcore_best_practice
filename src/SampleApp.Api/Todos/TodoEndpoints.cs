using SampleApp.Core.Todos;

namespace SampleApp.Api.Todos;

/// <summary>
/// Endpoints grouped per feature, kept out of Program.cs so it stays a thin
/// composition root.
/// </summary>
public static class TodoEndpoints
{
    public static IEndpointRouteBuilder MapTodoEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/todos").WithTags("Todos");

        group.MapGet("/", async (TodoService service, CancellationToken cancellationToken) =>
            Results.Ok(await service.ListAsync(cancellationToken)));

        group.MapPost("/", async (CreateTodoRequest request, TodoService service, CancellationToken cancellationToken) =>
        {
            if (string.IsNullOrWhiteSpace(request.Title))
            {
                return Results.BadRequest("Title must not be empty.");
            }

            var item = await service.AddAsync(request.Title, cancellationToken);
            return Results.Created($"/todos/{item.Id}", item);
        });

        group.MapPost("/{id:guid}/complete", async (Guid id, TodoService service, CancellationToken cancellationToken) =>
        {
            var item = await service.CompleteAsync(id, cancellationToken);
            return item is null ? Results.NotFound() : Results.Ok(item);
        });

        return app;
    }
}

public sealed record CreateTodoRequest(string Title);
