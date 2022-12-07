using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Recipes.API.Repositories;
using Recipes.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

var group = app.MapGroup("recipe")
    .WithOpenApi();

group.MapGet("{id}", (Guid id, IRecipeService service) => service.GetRecipeAsync(id));
group.MapGet("", (IRecipeService service) => service.GetRecipesAsync());
group.MapPut("", (Recipe recipe, IRecipeService service) => service.SaveRecipeAsync(recipe));
group.MapDelete("{id}", (Guid id, IRecipeService service) => service.DeleteRecipeAsync(id));

app.UseHttpsRedirection();

app.Run();
