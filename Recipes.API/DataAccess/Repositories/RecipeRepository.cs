namespace Recipes.API.DataAccess.Repositories;

public record Recipe(Guid Id, string Title, string[] Steps, int CookTimeMinutes, int PreparationTimeMinutes);

public interface IRecipeRepository
{
    Task<Recipe> GetRecipeAsync(Guid Id);

    Task<List<Recipe>> GetRecipesAsync();

    /// <summary>
    /// Update if non-existant, otherwise saves as new recipe.
    /// </summary>
    /// <param name="recipe"></param>
    /// <returns></returns>
    Task SaveRecipeAsync(Recipe recipe);

    Task DeleteRecipeAsync(Recipe recipe);
}


internal class RecipeRepository : IRecipeRepository
{
    private readonly ILogger<RecipeRepository> logger;
    private static List<Recipe> Recipes = new List<Recipe>();

    public RecipeRepository(
        ILogger<RecipeRepository> logger)
    {
        this.logger = logger;
    }

    public Task<Recipe> GetRecipeAsync(Guid Id)
    {
        return Task.FromResult(Recipes.SingleOrDefault(recipe => recipe.Id == Id));
    }

    public Task<List<Recipe>> GetRecipesAsync()
    {
        return Task.FromResult(Recipes);
    }

    public Task DeleteRecipeAsync(Recipe recipe)
    {
        Recipes.Remove(recipe);
        return Task.CompletedTask;
    }

    public Task SaveRecipeAsync(Recipe recipe)
    {
        Recipes.Add(recipe);
        return Task.CompletedTask;
    }
}
