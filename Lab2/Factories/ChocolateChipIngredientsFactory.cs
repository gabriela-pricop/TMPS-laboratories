using Lab2.Model;

namespace Lab2.Factories;

public class ChocolateChipCookieIngredientsFactory : IRecipeIngredientsFactory
{
    public IReadOnlyList<Ingredient> CreateDryIngredients() => new List<Ingredient>
    {
        new Ingredient("All-purpose flour", 279),
        new Ingredient("Baking soda", 5),
        new Ingredient("Salt", 6)
    };

    public IReadOnlyList<Ingredient> CreateFatsAndSugars() => new List<Ingredient>
    {
        new Ingredient("Butter, softened", 227),
        new Ingredient("Granulated sugar", 150),
        new Ingredient("Packed brown sugar", 150)
    };

    public IReadOnlyList<Ingredient> CreateWetIngredients() => new List<Ingredient>
    {
        new Ingredient("Large eggs (2)", 100),
        new Ingredient("Vanilla extract", 5)
    };

    public IReadOnlyList<Ingredient> CreateFlavourAdditions() => new List<Ingredient>
    {
        new Ingredient("Semi-sweet chocolate chips", 340)
    };
}