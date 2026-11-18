using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Models;

public class Ingredient
{
    public Ingredient(IngredientType type, double weightInGrams)
        : this(type, weightInGrams, string.Empty)
    {
    }

    public Ingredient(IngredientType type, double weightInGrams, string preparation)
    {
        Type = type;
        WeightInGrams = weightInGrams;
        Preparation = preparation;
    }

    public IngredientType Type { get; }

    public double WeightInGrams { get; }

    public string Preparation { get; }

    public double Calories => Type.CaloriesPer100Grams * WeightInGrams / 100.0;

    public override string ToString() =>
        Preparation.Length == 0
            ? $"{Type.Name} ({WeightInGrams} g)"
            : $"{Type.Name}, {Preparation} ({WeightInGrams} g)";
}