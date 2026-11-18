using Lab3.Domain.Models;

namespace Lab3.Patterns.Composite;

public class GiftBox : IBakedItem
{
    private readonly List<IBakedItem> items = new List<IBakedItem>();

    public GiftBox(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public IReadOnlyList<IBakedItem> Items => items;

    public GiftBox Add(IBakedItem item)
    {
        items.Add(item ?? throw new ArgumentNullException(nameof(item)));
        return this;
    }

    public bool Remove(IBakedItem item) => items.Remove(item);

    public IReadOnlyList<Ingredient> Ingredients =>
        items.SelectMany(item => item.Ingredients).ToList();

    public double TotalWeightInGrams => items.Sum(item => item.TotalWeightInGrams);

    public double TotalCalories => items.Sum(item => item.TotalCalories);

    public void Print(int indentLevel)
    {
        string pad = Indent.Of(indentLevel);

        Console.WriteLine($"{pad}[{Name}] - {items.Count} item(s), {TotalWeightInGrams} g");

        foreach (IBakedItem item in items)
        {
            item.Print(indentLevel + 1);
        }
    }
}