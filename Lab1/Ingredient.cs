namespace Lab1;

public class Ingredient
{
    public Ingredient(string type, double weightInGrams)
    {
        Type = type;
        WeightInGrams = weightInGrams;
    }

    public string Type { get; }

    public double WeightInGrams { get; }

    public override string ToString() => $"{Type} ({WeightInGrams} g)";
}
