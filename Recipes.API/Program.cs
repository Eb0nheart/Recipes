using Microsoft.AspNetCore.Mvc;
using Recipes.API.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var group = app.MapGroup("recipe")
    .WithOpenApi();

group.MapGet("{id}", (Guid id, IRecipeRepository repository) =>
{
    return repository.GetRecipeAsync(id);
});

group.MapGet("", (IRecipeRepository repository) => repository.GetRecipesAsync());

group.MapPut("", ([FromBody] Recipe recipe, IRecipeRepository repository) => repository.SaveRecipeAsync(recipe));

app.UseHttpsRedirection();

app.Run();
