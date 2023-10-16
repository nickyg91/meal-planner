using MealPlanner.Data.Contexts.MealPlanner;
using MealPlanner.Data.Contexts.MealPlanner.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("meal-planner");
builder.Services.AddDbContext<MealPlannerDbContext>(optionsAction =>
{
    if (builder.Environment.IsDevelopment())
    {
        optionsAction.EnableDetailedErrors();
        optionsAction.EnableSensitiveDataLogging();
    }
    optionsAction.UseNpgsql(connectionString, settings =>
    {
        settings.MigrationsAssembly("MealPlanner.Web");
    });
});

builder.Services.AddScoped<IMealRepository, MealRepository>();
builder.Services.AddScoped<IMealPlanRepository, MealPlanRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
