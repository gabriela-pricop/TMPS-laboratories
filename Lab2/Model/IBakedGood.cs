namespace Lab2.Model;

public interface IBakedGood
{
    string Name { get; }

    string Category { get; }

    double TotalWeightInGrams { get; }

    void PrintIngredients();
}