namespace Recipes.API.Repositories;

public record Recipe(int Id, string Title, string[] Steps, Ingredient[] Ingredients, TimeSpan CookTimeMinutes, TimeSpan PreparationTimeMinutes);

internal class RecipeRepository : Repository<Recipe>
{
    private readonly ILogger<RecipeRepository> logger;
    private static List<Recipe> Recipes = new List<Recipe>();

    public RecipeRepository(
        ILogger<RecipeRepository> logger)
    {
        this.logger = logger;
    }

    public Task<Recipe> GetAsync(int Id)
    {
        return Task.FromResult(Recipes.SingleOrDefault(recipe => recipe.Id == Id));
    }

    public Task<List<Recipe>> GetAsync()
    {
        return Task.FromResult(Recipes);
    }

    public Task DeleteAsync(Recipe recipe)
    {
        Recipes.Remove(recipe);
        return Task.CompletedTask;
    }

    public Task SaveAsync(Recipe recipe)
    {
        if(Recipes.Contains(recipe)) 
        {
            Recipes[Recipes.IndexOf(recipe)] = recipe;
            return Task.CompletedTask;
        }

        var recordToAdd = recipe with { Id = Recipes.Max(recipe => recipe.Id) + 1 };
        Recipes.Add(recordToAdd);
        return Task.CompletedTask;
    }
}
