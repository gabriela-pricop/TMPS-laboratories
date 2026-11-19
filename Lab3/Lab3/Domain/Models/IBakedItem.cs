namespace Lab3.Domain.Models;

public interface IBakedItem
{
    string Name { get; }

    IReadOnlyList<Ingredient> Ingredients { get; }

    double TotalWeightInGrams { get; }

    double TotalCalories { get; }

    string Describe(int indentLevel);
}