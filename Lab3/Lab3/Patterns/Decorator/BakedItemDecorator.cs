using Lab3.Domain.Models;

namespace Lab3.Patterns.Decorator;

public class BakedItemDecorator : IBakedItem
{
    protected BakedItemDecorator(IBakedItem inner)
    {
        Inner = inner ?? throw new ArgumentNullException(nameof(inner));
    }

    protected IBakedItem Inner { get; }

    public virtual string Name => Inner.Name;

    public virtual IReadOnlyList<Ingredient> Ingredients => Inner.Ingredients;

    public virtual double TotalWeightInGrams => Inner.TotalWeightInGrams;

    public virtual double TotalCalories => Inner.TotalCalories;

    public virtual void Print(int indentLevel) => Inner.Print(indentLevel);
}