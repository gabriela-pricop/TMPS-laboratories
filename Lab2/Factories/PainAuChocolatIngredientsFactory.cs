using Lab2.Model;

namespace Lab2.Factories;

public class PainAuChocolatIngredientsFactory : IRecipeIngredientsFactory
{
    public IReadOnlyList<Ingredient> CreateDryIngredients() => new List<Ingredient>
    {
        new Ingredient("Strong white bread flour", 500),
        new Ingredient("Salt", 6),
        new Ingredient("Easy-bake dried yeast", 7)
    };

    public IReadOnlyList<Ingredient> CreateFatsAndSugars() => new List<Ingredient>
    {
        new Ingredient("Unsalted butter, lamination block", 350),
        new Ingredient("Golden caster sugar", 75)
    };

    public IReadOnlyList<Ingredient> CreateWetIngredients() => new List<Ingredient>
    {
        new Ingredient("Water", 270)
    };

    public IReadOnlyList<Ingredient> CreateFlavourAdditions() => new List<Ingredient>
    {
        new Ingredient("Dark chocolate batons (70%)", 250)
    };
}