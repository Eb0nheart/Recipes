using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.API.DataAccess;

public class Ingredient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Amount { get; set; }
    public MacroNutrients Nutrients { get; set; }
    public int RecipeId { get; set; }
    public Recipe Recipe { get; set; }
}