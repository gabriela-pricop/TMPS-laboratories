using Lab3.Domain.Models;

namespace TestLab3.TestDoubles;

// A minimal IBakedItem with fixed values, so tests can check exact sums
// without depending on the real recipes.
internal sealed class StubBakedItem : IBakedItem
{
    public StubBakedItem(string name, double weightInGrams, double calories, params Ingredient[] ingredients)
    {
        Name = name;
        TotalWeightInGrams = weightInGrams;
        TotalCalories = calories;
        Ingredients = ingredients;
    }

    public string Name { get; }

    public IReadOnlyList<Ingredient> Ingredients { get; }

    public double TotalWeightInGrams { get; }

    public double TotalCalories { get; }

    public string Describe(int indentLevel) => $"{Indent.Of(indentLevel)}{Name}{Environment.NewLine}";
}