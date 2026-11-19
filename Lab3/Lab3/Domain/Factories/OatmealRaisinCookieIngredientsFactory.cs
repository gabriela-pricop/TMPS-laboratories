using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Factories;

public class OatmealRaisinCookieIngredientsFactory : IRecipeIngredientsFactory
{
    private readonly IIngredientTypeProvider types;

    public OatmealRaisinCookieIngredientsFactory(IIngredientTypeProvider types)
    {
        this.types = types;
    }

    public IReadOnlyList<Ingredient> CreateDryIngredients() => new List<Ingredient>
    {
        new Ingredient(types.Get("All-purpose flour"), 170),
        new Ingredient(types.Get("Rolled oats"), 200, "old-fashioned"),
        new Ingredient(types.Get("Ground cinnamon"), 3),
        new Ingredient(types.Get("Baking soda"), 3),
        new Ingredient(types.Get("Salt"), 6)
    };

    public IReadOnlyList<Ingredient> CreateFatsAndSugars() => new List<Ingredient>
    {
        new Ingredient(types.Get("Unsalted butter"), 170, "melted and warm"),
        new Ingredient(types.Get("Brown sugar"), 200, "packed light"),
        new Ingredient(types.Get("Granulated sugar"), 200)
    };

    public IReadOnlyList<Ingredient> CreateWetIngredients() => new List<Ingredient>
    {
        new Ingredient(types.Get("Large eggs"), 50, "1 egg"),
        new Ingredient(types.Get("Vanilla extract"), 13)
    };

    public IReadOnlyList<Ingredient> CreateFlavourAdditions() => new List<Ingredient>
    {
        new Ingredient(types.Get("Raisins"), 150)
    };
}