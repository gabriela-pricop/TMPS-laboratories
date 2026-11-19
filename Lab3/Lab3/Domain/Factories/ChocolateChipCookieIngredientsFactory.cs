using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Factories;

public class ChocolateChipCookieIngredientsFactory : IRecipeIngredientsFactory
{
    private readonly IIngredientTypeProvider types;

    public ChocolateChipCookieIngredientsFactory(IIngredientTypeProvider types)
    {
        this.types = types;
    }

    public IReadOnlyList<Ingredient> CreateDryIngredients() => new List<Ingredient>
    {
        new Ingredient(types.Get("All-purpose flour"), 279),
        new Ingredient(types.Get("Baking soda"), 5),
        new Ingredient(types.Get("Salt"), 6)
    };

    public IReadOnlyList<Ingredient> CreateFatsAndSugars() => new List<Ingredient>
    {
        new Ingredient(types.Get("Unsalted butter"), 227, "softened"),
        new Ingredient(types.Get("Granulated sugar"), 150),
        new Ingredient(types.Get("Brown sugar"), 150, "packed")
    };

    public IReadOnlyList<Ingredient> CreateWetIngredients() => new List<Ingredient>
    {
        new Ingredient(types.Get("Large eggs"), 100, "2 eggs"),
        new Ingredient(types.Get("Vanilla extract"), 5)
    };

    public IReadOnlyList<Ingredient> CreateFlavourAdditions() => new List<Ingredient>
    {
        new Ingredient(types.Get("Semi-sweet chocolate chips"), 340)
    };
}