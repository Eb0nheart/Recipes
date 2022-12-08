namespace Recipes.API.Repositories;

/// <param name="Kcal">Kcal pr 100g of the ingredient</param>
public record Ingredient(int Id, string Name, string Amount, MacroNutrients Nutrients);

/// <summary>
/// Nutrients pr 100g of the ingredient
/// </summary>
public record MacroNutrients(double Kcal, double Protein, double Fat, double Carbohydrate);

public class IngredientRepository : Repository<Ingredient>
{
    public Task DeleteAsync(Ingredient item)
    {
        throw new NotImplementedException();
    }

    public Task<Ingredient> GetAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Ingredient>> GetAsync()
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(Ingredient item)
    {
        throw new NotImplementedException();
    }
}
