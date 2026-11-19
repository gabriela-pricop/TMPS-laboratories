using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Patterns.Decorator;

public class WalnutCoating : BakedItemDecorator
{
    private readonly Ingredient topping;

    public WalnutCoating(IBakedItem inner, IIngredientTypeProvider types)
        : base(inner)
    {
        topping = new Ingredient(types.Get("Walnuts"), 30, "chopped, rolled in");
    }

    public override string Name => $"{Inner.Name} + walnut coating";

    public override IReadOnlyList<Ingredient> Ingredients =>
        Inner.Ingredients.Append(topping).ToList();

    public override double TotalWeightInGrams =>
        Inner.TotalWeightInGrams + topping.WeightInGrams;

    public override double TotalCalories => Inner.TotalCalories + topping.Calories;

    public override string Describe(int indentLevel) =>
        Inner.Describe(indentLevel)
        + $"{Indent.Of(indentLevel + 1)}+ {topping}{Environment.NewLine}";
}