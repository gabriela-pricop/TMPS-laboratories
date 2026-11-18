using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Factories;

public class BananaNutMuffinIngredientsFactory
{
    private readonly IngredientTypeFactory types;

    public BananaNutMuffinIngredientsFactory(IngredientTypeFactory types)
    {
        this.types = types;
    }

    public IReadOnlyList<Ingredient> CreateDryIngredients() => new List<Ingredient>
    {
        new Ingredient(types.Get("All-purpose flour"), 210),
        new Ingredient(types.Get("Baking soda"), 5),
        new Ingredient(types.Get("Salt"), 1)
    };

    public IReadOnlyList<Ingredient> CreateFatsAndSugars() => new List<Ingredient>
    {
        new Ingredient(types.Get("Unsalted butter"), 75, "melted"),
        new Ingredient(types.Get("Granulated sugar"), 160)
    };

    public IReadOnlyList<Ingredient> CreateWetIngredients() => new List<Ingredient>
    {
        new Ingredient(types.Get("Large eggs"), 50, "1 egg"),
        new Ingredient(types.Get("Bananas"), 400, "mashed, ripe"),
        new Ingredient(types.Get("Vanilla extract"), 4)
    };

    public IReadOnlyList<Ingredient> CreateFlavourAdditions() => new List<Ingredient>
    {
        new Ingredient(types.Get("Walnuts"), 115, "chopped")
    };
}