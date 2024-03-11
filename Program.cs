using TodoListApp.Components;
using TodoListApp.Contexts;
using TodoListApp.Repositories;
using TodoListApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Infra
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped(typeof(TodoContext), typeof(TodoContext));

// Services
builder.Services.AddScoped<TodoService, TodoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
