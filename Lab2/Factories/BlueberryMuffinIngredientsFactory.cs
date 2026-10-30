using Lab2.Model;

namespace Lab2.Factories;

public class BlueberryMuffinIngredientsFactory : IRecipeIngredientsFactory
{
    public IReadOnlyList<Ingredient> CreateDryIngredients() => new List<Ingredient>
    {
        new Ingredient("All-purpose flour", 240),
        new Ingredient("Baking powder", 8),
        new Ingredient("Ground cinnamon", 1),
        new Ingredient("Salt", 2)
    };

    public IReadOnlyList<Ingredient> CreateFatsAndSugars() => new List<Ingredient>
    {
        new Ingredient("Butter, browned", 113),
        new Ingredient("Granulated sugar", 200)
    };

    public IReadOnlyList<Ingredient> CreateWetIngredients() => new List<Ingredient>
    {
        new Ingredient("Large eggs (2)", 100),
        new Ingredient("Milk", 120),
        new Ingredient("Vanilla extract", 7),
        new Ingredient("Almond extract", 2)
    };

    public IReadOnlyList<Ingredient> CreateFlavourAdditions() => new List<Ingredient>
    {
        new Ingredient("Blueberries", 300)
    };
}