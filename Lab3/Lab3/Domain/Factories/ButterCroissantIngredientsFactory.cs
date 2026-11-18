using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Factories;

public class ButterCroissantIngredientsFactory
{
    private readonly IngredientTypeFactory types;

    public ButterCroissantIngredientsFactory(IngredientTypeFactory types)
    {
        this.types = types;
    }

    public IReadOnlyList<Ingredient> CreateDryIngredients() => new List<Ingredient>
    {
        new Ingredient(types.Get("All-purpose flour"), 500),
        new Ingredient(types.Get("Salt"), 10)
    };

    public IReadOnlyList<Ingredient> CreateFatsAndSugars() => new List<Ingredient>
    {
        new Ingredient(types.Get("Unsalted butter"), 250, "lamination block"),
        new Ingredient(types.Get("Unsalted butter"), 35, "melted and cooled"),
        new Ingredient(types.Get("Granulated sugar"), 65)
    };

    public IReadOnlyList<Ingredient> CreateWetIngredients() => new List<Ingredient>
    {
        new Ingredient(types.Get("Water"), 150, "cold"),
        new Ingredient(types.Get("Whole milk"), 100, "cold"),
        new Ingredient(types.Get("Fresh yeast"), 20)
    };

    public IReadOnlyList<Ingredient> CreateFlavourAdditions() => new List<Ingredient>();
}