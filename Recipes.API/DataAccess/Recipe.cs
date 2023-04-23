using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Recipes.API.DataAccess;

public class Recipe
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Title { get; set; }
    public Step[] Steps { get; set; }
    public Ingredient[] Ingredients { get; set; }
    public TimeSpan CookTimeMinutes { get; set; }
    public TimeSpan PreparationTimeMinutes { get; set; }
}

public class Step
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Description { get; set; }

    public int RecipeId { get; set; }

    public Recipe Recipe { get; set; }
}