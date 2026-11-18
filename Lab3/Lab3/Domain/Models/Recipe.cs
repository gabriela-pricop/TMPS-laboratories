namespace Lab3.Domain.Models;

public class Recipe
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

    public void Print(int indentLevel)
    {
        string pad = Indent.Of(indentLevel);

        Console.WriteLine($"{pad}{Name} ({Category}) - {TotalWeightInGrams} g");
        PrintGroup("Dry", DryIngredients, indentLevel + 1);
        PrintGroup("Fats and sugars", FatsAndSugars, indentLevel + 1);
        PrintGroup("Wet", WetIngredients, indentLevel + 1);
        PrintGroup("Flavour additions", FlavourAdditions, indentLevel + 1);
    }

    private static void PrintGroup(string title, IReadOnlyList<Ingredient> ingredients, int indentLevel)
    {
        string pad = Indent.Of(indentLevel);

        Console.WriteLine($"{pad}{title}:");

        if (ingredients.Count == 0)
        {
            Console.WriteLine($"{Indent.Of(indentLevel + 1)}- none");
            return;
        }

        foreach (Ingredient ingredient in ingredients)
        {
            Console.WriteLine($"{Indent.Of(indentLevel + 1)}- {ingredient}");
        }
    }
}