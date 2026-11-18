namespace Lab3.Domain.Models;

public class IBakedItem
{
    string Name { get; }

    IReadOnlyList<Ingredient> Ingredients { get; }

    double TotalWeightInGrams { get; }

    double TotalCalories { get; }

    void Print(int indentLevel);
}