using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProjectBoard.Components;
using ProjectBoard.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetSection("MariaDb").Value;

var serverVersion = MariaDbServerVersion.AutoDetect(connectionString);

builder.Services.AddEntityFrameworkMySql()
    .AddDbContext<ProjectDbContext>(opt => opt.UseMySql(connectionString, serverVersion));

builder.Services.AddScoped<Projects>();

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
