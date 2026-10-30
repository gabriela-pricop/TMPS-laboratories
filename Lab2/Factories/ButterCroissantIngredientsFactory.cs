using Lab2.Model;

namespace Lab2.Factories;

public class ButterCroissantIngredientsFactory : IRecipeIngredientsFactory
{
    public IReadOnlyList<Ingredient> CreateDryIngredients() => new List<Ingredient>
    {
        new Ingredient("All-purpose flour", 500),
        new Ingredient("Fine salt", 10)
    };

    public IReadOnlyList<Ingredient> CreateFatsAndSugars() => new List<Ingredient>
    {
        new Ingredient("Unsalted butter, lamination block", 250),
        new Ingredient("Butter, melted and cooled", 35),
        new Ingredient("Granulated sugar", 65)
    };

    public IReadOnlyList<Ingredient> CreateWetIngredients() => new List<Ingredient>
    {
        new Ingredient("Cold water", 150),
        new Ingredient("Cold whole milk", 100),
        new Ingredient("Fresh baker's yeast", 20)
    };

    // A plain butter croissant carries no filling, but the family contract
    // still has to be honoured, so an empty group is returned.
    public IReadOnlyList<Ingredient> CreateFlavourAdditions() => new List<Ingredient>();
}