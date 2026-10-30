namespace Lab2.Model;

public class Recipe : IBakedGood
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

    public double TotalWeightInGrams =>
        DryIngredients.Sum(i => i.WeightInGrams)
        + FatsAndSugars.Sum(i => i.WeightInGrams)
        + WetIngredients.Sum(i => i.WeightInGrams)
        + FlavourAdditions.Sum(i => i.WeightInGrams);

    public void PrintIngredients()
    {
        Console.WriteLine($"--- {Name} ({Category}) ---");
        PrintGroup("Dry", DryIngredients);
        PrintGroup("Fats and sugars", FatsAndSugars);
        PrintGroup("Wet", WetIngredients);
        PrintGroup("Flavour additions", FlavourAdditions);
        Console.WriteLine($"  Total weight: {TotalWeightInGrams} g");
    }

    private static void PrintGroup(string title, IReadOnlyList<Ingredient> ingredients)
    {
        Console.WriteLine($"  {title}:");

        if (ingredients.Count == 0)
        {
            Console.WriteLine("    - none");
            return;
        }

        foreach (Ingredient ingredient in ingredients)
        {
            Console.WriteLine($"    - {ingredient}");
        }
    }
}