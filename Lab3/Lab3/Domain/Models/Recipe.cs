using System.Text;

namespace Lab3.Domain.Models;

public class Recipe : IBakedItem
{
    public Recipe(
        string name,
        string category,
        IReadOnlyList<Ingredient> dryIngredients,
        IReadOnlyList<Ingredient> fatsAndSugars,
        IReadOnlyList<Ingredient> wetIngredients,
        IReadOnlyList<Ingredient> flavourAdditions)
    {
        Name = name;
        Category = category;
        DryIngredients = dryIngredients;
        FatsAndSugars = fatsAndSugars;
        WetIngredients = wetIngredients;
        FlavourAdditions = flavourAdditions;
    }

    public string Name { get; }

    public string Category { get; }

    public IReadOnlyList<Ingredient> DryIngredients { get; }

    public IReadOnlyList<Ingredient> FatsAndSugars { get; }

    public IReadOnlyList<Ingredient> WetIngredients { get; }

    public IReadOnlyList<Ingredient> FlavourAdditions { get; }

    public IReadOnlyList<Ingredient> Ingredients =>
        DryIngredients
            .Concat(FatsAndSugars)
            .Concat(WetIngredients)
            .Concat(FlavourAdditions)
            .ToList();

    public double TotalWeightInGrams => Ingredients.Sum(i => i.WeightInGrams);

    public double TotalCalories => Ingredients.Sum(i => i.Calories);

    public string Describe(int indentLevel)
    {
        StringBuilder text = new StringBuilder();

        text.AppendLine($"{Indent.Of(indentLevel)}{Name} ({Category}) - {TotalWeightInGrams} g");
        AppendGroup(text, "Dry", DryIngredients, indentLevel + 1);
        AppendGroup(text, "Fats and sugars", FatsAndSugars, indentLevel + 1);
        AppendGroup(text, "Wet", WetIngredients, indentLevel + 1);
        AppendGroup(text, "Flavour additions", FlavourAdditions, indentLevel + 1);

        return text.ToString();
    }

    private static void AppendGroup(
        StringBuilder text,
        string title,
        IReadOnlyList<Ingredient> ingredients,
        int indentLevel)
    {
        text.AppendLine($"{Indent.Of(indentLevel)}{title}:");

        if (ingredients.Count == 0)
        {
            text.AppendLine($"{Indent.Of(indentLevel + 1)}- none");
            return;
        }

        foreach (Ingredient ingredient in ingredients)
        {
            text.AppendLine($"{Indent.Of(indentLevel + 1)}- {ingredient}");
        }
    }
}