using Microsoft.EntityFrameworkCore;

namespace Recipes.API.DataAccess.Repositories;

public class IngredientRepository 
{
    private readonly ILogger<IngredientRepository> logger;
    private readonly RecipesContext context;

    public IngredientRepository(
        ILogger<IngredientRepository> logger,
        RecipesContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public async Task DeleteAsync(Ingredient item)
    {
        try
        {
            context.Ingredients.Remove(item);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Kunne ikke slette ingrediens: {@Ingrediens}", item);
        }
    }

    public async Task<Ingredient> GetAsync(int id)
    {
        return await context.Ingredients.FindAsync(id);
    }

    public Task<List<Ingredient>> GetAsync()
    {
        return Task.FromResult(context.Ingredients.ToList());
    }

    public async Task SaveAsync(Ingredient item)
    {
        try
        {
            context.Ingredients.Attach(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Kunne ikke opdatere ingrediens: {@Ingrediens}", item);
        }
    }
}
