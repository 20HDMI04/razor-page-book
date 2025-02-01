using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using bookshelf.Data;
using bookshelf.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<bookshelfContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("bookshelfContext") ?? throw new InvalidOperationException("Connection string 'bookshelfContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
