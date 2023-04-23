using Microsoft.AspNetCore.Mvc;
using Recipes.API.DataAccess;
using Recipes.API.DataAccess.Repositories;

namespace Recipes.API.Controller;

[Route("[controller]")]
public class RecipeController : ControllerBase
{
    private readonly RecipeRepository repository;

    public RecipeController(RecipeRepository repository)
    {
        this.repository = repository;
    }

    [HttpDelete]
    public async Task<IResult> DeleteRecipeAsync(int id)
    {
        var recipeToDelete = await repository.GetAsync(id);

        if(recipeToDelete == null) 
        {
            return TypedResults.BadRequest("Recipe doesn't exist and cannot be deleted!");
        }

        await repository.DeleteAsync(recipeToDelete);
        return TypedResults.NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetRecipeAsync(int id)
    {
        var recipe = await repository.GetAsync(id);

        if(recipe == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(recipe);
    }

    [HttpGet]
    public async Task<IResult> GetRecipesAsync()
    {
        var recipes = await repository.GetAsync();
        return TypedResults.Ok(recipes);
    }

    [HttpPost]
    public async Task<IResult> AddRecipeAsync(Recipe recipe)
    {
        await repository.AddAsync(recipe);
        return TypedResults.Created($"/recipe/{recipe.Id}", recipe);
    }

    [HttpPut]
    public async Task<IResult> SaveRecipeAsync(Recipe recipe)
    {
        await repository.SaveAsync(recipe);
        return TypedResults.Ok();
    }
}
