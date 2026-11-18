using Lab3.Domain.Builders;
using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Shops;

public abstract class BakeryShop
{
    protected BakeryShop(IngredientTypeFactory types)
    {
        Types = types;
        Director = new RecipeDirector(new RecipeBuilder());
    }

    public abstract string ShopName { get; }

    public abstract IReadOnlyList<string> Menu { get; }

    protected IngredientTypeFactory Types { get; }

    protected RecipeDirector Director { get; }

    protected abstract IBakedItem CreateBakedItem(int menuPosition);

    public IBakedItem Order(int menuPosition)
    {
        if (menuPosition < 1 || menuPosition > Menu.Count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(menuPosition),
                $"{ShopName} has no product at position {menuPosition}.");
        }

        return CreateBakedItem(menuPosition);
    }

    public void PrintMenu()
    {
        Console.WriteLine($"{ShopName}");

        for (int i = 0; i < Menu.Count; i++)
        {
            Console.WriteLine($"  {i + 1}) {Menu[i]}");
        }
    }
}