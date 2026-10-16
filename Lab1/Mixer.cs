namespace Lab1;

public class Mixer : ICombineIngredients
{
    private readonly Cookie cookie;

    public Mixer(Cookie cookie)
    {
        this.cookie = cookie;
    }

    public void MixDryIngredients()
    {
        Console.WriteLine("Whisking the dry ingredients together:");

        foreach (var ingredient in cookie.DryIngredients)
        {
            Console.WriteLine($"  - {ingredient.Type}: {ingredient.WeightInGrams} g");
        }

        Console.WriteLine(
            $"The dry mix is ready ({cookie.DryIngredients.Sum(i => i.WeightInGrams)} g).");
    }

    public void MixButterSugars()
    {
        Console.WriteLine($"Beating until creamy: {string.Join(", ", cookie.ButterAndSugars)}.");
    }

    public void MixAllIngredients()
    {
        Console.WriteLine($"Beating in: {string.Join(", ", cookie.WetIngredients)}.");
        Console.WriteLine("Gradually stirring the dry mix into the creamy mixture until a dough forms.");
    }

    public void AddMixIns()
    {
        foreach (Ingredient mixIn in cookie.MixIns)
        {
            Console.WriteLine($"Folding in: {mixIn}.");
        }
    }
}
