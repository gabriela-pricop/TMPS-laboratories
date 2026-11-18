namespace Lab3.Patterns.Flyweight;

public class IngredientType
{
    internal IngredientType(string name, double caloriesPer100Grams, string allergen)
    {
        Name = name;
        CaloriesPer100Grams = caloriesPer100Grams;
        Allergen = allergen;
    }

    public string Name { get; }

    public double CaloriesPer100Grams { get; }

    public string Allergen { get; }

    public bool HasAllergen => Allergen.Length > 0;

    public override string ToString() => Name;
}