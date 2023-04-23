using Microsoft.EntityFrameworkCore;

namespace Recipes.API.DataAccess;

public class RecipesContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<MacroNutrients> MacroNutrients { get; set; }

    public RecipesContext(DbContextOptions options) : base(options)
    {

    }

}
