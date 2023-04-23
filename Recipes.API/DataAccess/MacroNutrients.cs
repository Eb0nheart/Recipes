using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Recipes.API.DataAccess;

public class MacroNutrients
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public double Kcal { get; set; }
    public double Protein { get; set; }
    public double Fat { get; set; }
    public double Carbohydrate { get; set; }
    public int IngredientId { get; set; }
    public Ingredient Ingredient { get; set; }
}