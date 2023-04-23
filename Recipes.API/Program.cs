using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Recipes.API.Controller;
using Recipes.API.DataAccess;
using Recipes.API.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<RecipeRepository>();
builder.Services.AddScoped<RecipeController>();
builder.Services.AddDbContext<RecipesContext>(options =>
{
    options.UseInMemoryDatabase("Recipes");
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    options => options.MapType<TimeSpan>(
        () => new OpenApiSchema { Type = "string", Example = new OpenApiString("00:00:00") }));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
