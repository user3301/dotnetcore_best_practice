using SampleApp.Api.Todos;
using SampleApp.Core.Todos;
using SampleApp.Infrastructure.Todos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();
builder.Services.AddScoped<TodoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapTodoEndpoints();

app.Run();

// Exposes the implicit Program class to WebApplicationFactory<Program>
// in the integration test project.
public partial class Program;
