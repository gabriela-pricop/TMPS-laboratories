using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Patterns.Decorator;

public class ChocolateDrizzle : BakedItemDecorator
{
    private readonly Ingredient topping;

    public ChocolateDrizzle(IBakedItem inner, IIngredientTypeProvider types)
        : base(inner)
    {
        topping = new Ingredient(types.Get("Dark chocolate"), 45, "melted, drizzled");
    }

    public override string Name => $"{Inner.Name} + chocolate drizzle";

    public override IReadOnlyList<Ingredient> Ingredients =>
        Inner.Ingredients.Append(topping).ToList();

    public override double TotalWeightInGrams =>
        Inner.TotalWeightInGrams + topping.WeightInGrams;

    public override double TotalCalories => Inner.TotalCalories + topping.Calories;

    public override string Describe(int indentLevel) =>
        Inner.Describe(indentLevel)
        + $"{Indent.Of(indentLevel + 1)}+ {topping}{Environment.NewLine}";
}