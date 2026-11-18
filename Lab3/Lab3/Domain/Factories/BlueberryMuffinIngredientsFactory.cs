using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Factories;

public class BlueberryMuffinIngredientsFactory
{
    private readonly IngredientTypeFactory types;

    public BlueberryMuffinIngredientsFactory(IngredientTypeFactory types)
    {
        this.types = types;
    }

    public IReadOnlyList<Ingredient> CreateDryIngredients() => new List<Ingredient>
    {
        new Ingredient(types.Get("All-purpose flour"), 240),
        new Ingredient(types.Get("Baking powder"), 8),
        new Ingredient(types.Get("Ground cinnamon"), 1),
        new Ingredient(types.Get("Salt"), 2)
    };

    public IReadOnlyList<Ingredient> CreateFatsAndSugars() => new List<Ingredient>
    {
        new Ingredient(types.Get("Unsalted butter"), 113, "browned"),
        new Ingredient(types.Get("Granulated sugar"), 200)
    };

    public IReadOnlyList<Ingredient> CreateWetIngredients() => new List<Ingredient>
    {
        new Ingredient(types.Get("Large eggs"), 100, "2 eggs"),
        new Ingredient(types.Get("Whole milk"), 120),
        new Ingredient(types.Get("Vanilla extract"), 7)
    };

    public IReadOnlyList<Ingredient> CreateFlavourAdditions() => new List<Ingredient>
    {
        new Ingredient(types.Get("Blueberries"), 300)
    };
}