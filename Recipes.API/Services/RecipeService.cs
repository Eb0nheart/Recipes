using Microsoft.AspNetCore.Http.HttpResults;
using Recipes.API.Repositories;

namespace Recipes.API.Services;

public interface IRecipeService
{
    Task<Results<Ok<Recipe>, NotFound>> GetRecipeAsync(Guid Id);

    Task<IResult> GetRecipesAsync();

    /// <summary>
    /// Update if non-existant, otherwise saves as new recipe.
    /// </summary>
    /// <param name="recipe"></param>
    /// <returns></returns>
    Task<Results<Created<Recipe>, BadRequest>> SaveRecipeAsync(Recipe recipe);

    Task<Results<NoContent, BadRequest<string>>> DeleteRecipeAsync(Guid id);
}

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository repository;

    public RecipeService(IRecipeRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Results<NoContent, BadRequest<string>>> DeleteRecipeAsync(Guid id)
    {
        var recipeToDelete = await repository.GetRecipeAsync(id);

        if(recipeToDelete == null) 
        {
            return TypedResults.BadRequest("Recipe doesn't exist and cannot be deleted!");
        }

        await repository.DeleteRecipeAsync(recipeToDelete);
        return TypedResults.NoContent();
    }

    public async Task<Results<Ok<Recipe>, NotFound>> GetRecipeAsync(Guid Id)
    {
        var recipe = await repository.GetRecipeAsync(Id);

        if(recipe == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(recipe);
    }

    public async Task<IResult> GetRecipesAsync()
    {
        var recipes = await repository.GetRecipesAsync();
        return TypedResults.Ok(recipes);
    }

    public async Task<Results<Created<Recipe>, BadRequest>> SaveRecipeAsync(Recipe recipe)
    {
        await repository.SaveRecipeAsync(recipe);
        return TypedResults.Created($"/recipe/{recipe.Id}", recipe);
    }
}
