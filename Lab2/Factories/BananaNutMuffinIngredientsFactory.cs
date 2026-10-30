using Lab2.Model;

namespace Lab2.Factories;

public class BananaNutMuffinIngredientsFactory : IRecipeIngredientsFactory
{
    public IReadOnlyList<Ingredient> CreateDryIngredients() => new List<Ingredient>
    {
        new Ingredient("All-purpose flour", 210),
        new Ingredient("Baking soda", 5),
        new Ingredient("Salt", 1)
    };

    public IReadOnlyList<Ingredient> CreateFatsAndSugars() => new List<Ingredient>
    {
        new Ingredient("Butter, melted", 75),
        new Ingredient("Granulated sugar", 160)
    };

    public IReadOnlyList<Ingredient> CreateWetIngredients() => new List<Ingredient>
    {
        new Ingredient("Large egg", 50),
        new Ingredient("Mashed ripe bananas", 400),
        new Ingredient("Vanilla extract", 4)
    };

    public IReadOnlyList<Ingredient> CreateFlavourAdditions() => new List<Ingredient>
    {
        new Ingredient("Chopped walnuts", 115)
    };
}