using Microsoft.EntityFrameworkCore;
using OrderApi.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OrderDbContext>(
    options =>
    {
        options.UseNpgsql(
            builder.Configuration.GetConnectionString(
                "PostgresConnection"));
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "ui-policy",
        policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
        });
});

var app = builder.Build();

app.UseStaticFiles();

app.UseCors("ui-policy");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<OrderDbContext>();

    db.Database.Migrate();
}

app.Run();