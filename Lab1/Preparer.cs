namespace Lab1;

public class Preparer : IPreparation
{
    private readonly Cookie cookie;

    public Preparer(Cookie cookie)
    {
        this.cookie = cookie;
    }

    public void PrepareIngredients()
    {
        Console.WriteLine($"Ingredients for {cookie.Name}:");
        PrintSection("Dry", cookie.DryIngredients);
        PrintSection("Butter and sugars", cookie.ButterAndSugars);
        PrintSection("Wet", cookie.WetIngredients);
        PrintSection("Mix-ins", cookie.MixIns);
    }

    public void PrepareTools()
    {
        Console.WriteLine($"Tools needed: {string.Join(", ", cookie.Tools)}.");
    }

    private static void PrintSection(string title, IReadOnlyList<Ingredient> ingredients)
    {
        Console.WriteLine($"  {title}:");
        foreach (Ingredient ingredient in ingredients)
        {
            Console.WriteLine($"    - {ingredient}");
        }
    }
}
