using Microsoft.EntityFrameworkCore;

namespace Recipes.API.DataAccess.Repositories;

public class RecipeRepository
{
    private readonly ILogger<RecipeRepository> logger;
    private readonly RecipesContext context;

    public RecipeRepository(
        ILogger<RecipeRepository> logger,
        RecipesContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public async Task<Recipe> GetAsync(int id)
    {
        return await context.Recipes.FindAsync(id);
    }

    public Task<List<Recipe>> GetAsync()
    {
        return Task.FromResult(context.Recipes.ToList());
    }

    public async Task DeleteAsync(Recipe recipe)
    {
        try
        {
            context.Recipes.Remove(recipe);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Kunne ikke slette opskrift: {@Opskrift}", recipe);
        }
    }

    public async Task SaveAsync(Recipe recipe)
    {
        try
        {
            context.Recipes.Attach(recipe).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Kunne ikke opdatere opskrift: {@Opskrift}", recipe);
        }
    }

    public async Task AddAsync(Recipe recipe)
    {
        await context.Recipes.AddAsync(recipe);
        await context.SaveChangesAsync();
    }
}
