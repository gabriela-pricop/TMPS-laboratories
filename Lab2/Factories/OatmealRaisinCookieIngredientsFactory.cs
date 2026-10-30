using Lab2.Model;

namespace Lab2.Factories;

public class OatmealRaisinCookieIngredientsFactory : IRecipeIngredientsFactory
{
    public IReadOnlyList<Ingredient> CreateDryIngredients() => new List<Ingredient>
    {
        new Ingredient("All-purpose flour", 170),
        new Ingredient("Old-fashioned rolled oats", 200),
        new Ingredient("Ground cinnamon", 3),
        new Ingredient("Baking soda", 3),
        new Ingredient("Kosher salt", 6)
    };

    public IReadOnlyList<Ingredient> CreateFatsAndSugars() => new List<Ingredient>
    {
        new Ingredient("Unsalted butter, melted and warm", 170),
        new Ingredient("Packed light brown sugar", 200),
        new Ingredient("Granulated sugar", 200)
    };

    public IReadOnlyList<Ingredient> CreateWetIngredients() => new List<Ingredient>
    {
        new Ingredient("Large egg", 50),
        new Ingredient("Vanilla extract", 13)
    };

    public IReadOnlyList<Ingredient> CreateFlavourAdditions() => new List<Ingredient>
    {
        new Ingredient("Raisins", 150)
    };
}