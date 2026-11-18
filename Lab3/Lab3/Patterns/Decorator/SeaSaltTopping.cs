using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Patterns.Decorator;

public class SeaSaltTopping : BakedItemDecorator
{
    private readonly Ingredient topping;

    public SeaSaltTopping(IBakedItem inner, IngredientTypeFactory types)
        : base(inner)
    {
        topping = new Ingredient(types.Get("Salt"), 4, "flaky, sprinkled on top");
    }

    public override string Name => $"{Inner.Name} + sea salt";

    public override IReadOnlyList<Ingredient> Ingredients =>
        Inner.Ingredients.Append(topping).ToList();

    public override double TotalWeightInGrams =>
        Inner.TotalWeightInGrams + topping.WeightInGrams;

    public override double TotalCalories => Inner.TotalCalories + topping.Calories;

    public override void Print(int indentLevel)
    {
        Inner.Print(indentLevel);
        Console.WriteLine($"{Indent.Of(indentLevel + 1)}+ {topping}");
    }
}