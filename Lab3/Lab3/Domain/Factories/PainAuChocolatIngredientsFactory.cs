using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Factories;

public class PainAuChocolatIngredientsFactory
{
    private readonly IngredientTypeFactory types;

    public PainAuChocolatIngredientsFactory(IngredientTypeFactory types)
    {
        this.types = types;
    }

    public IReadOnlyList<Ingredient> CreateDryIngredients() => new List<Ingredient>
    {
        new Ingredient(types.Get("Bread flour"), 500, "strong white"),
        new Ingredient(types.Get("Salt"), 6),
        new Ingredient(types.Get("Dried yeast"), 7, "easy-bake")
    };

    public IReadOnlyList<Ingredient> CreateFatsAndSugars() => new List<Ingredient>
    {
        new Ingredient(types.Get("Unsalted butter"), 350, "lamination block"),
        new Ingredient(types.Get("Caster sugar"), 75, "golden")
    };

    public IReadOnlyList<Ingredient> CreateWetIngredients() => new List<Ingredient>
    {
        new Ingredient(types.Get("Water"), 270)
    };

    public IReadOnlyList<Ingredient> CreateFlavourAdditions() => new List<Ingredient>
    {
        new Ingredient(types.Get("Dark chocolate"), 250, "batons, 70%")
    };
}