using Lab2.Builders;
using Lab2.Model;

namespace Lab2.Shops;

public abstract class BakeryShop
{
    protected BakeryShop()
    {
        Director = new RecipeDirector(new RecipeBuilder());
    }

    public abstract string ShopName { get; }

    public abstract IReadOnlyList<string> Menu { get; }

    protected RecipeDirector Director { get; }

    // The factory method. Each shop decides which baked good a menu
    // position stands for; this class never knows the concrete type.
    protected abstract IBakedGood CreateBakedGood(int menuPosition);

    public IBakedGood Order(int menuPosition)
    {
        if (menuPosition < 1 || menuPosition > Menu.Count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(menuPosition),
                $"{ShopName} has no product at position {menuPosition}.");
        }

        return CreateBakedGood(menuPosition);
    }

    public void PrintMenu()
    {
        Console.WriteLine($"{ShopName}");

        for (int i = 0; i < Menu.Count; i++)
        {
            Console.WriteLine($"  {i + 1}) {Menu[i]}");
        }

        Console.WriteLine("  0) Back");
    }
}
