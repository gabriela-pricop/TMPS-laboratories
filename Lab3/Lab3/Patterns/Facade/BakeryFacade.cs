using Lab3.Domain.Models;
using Lab3.Domain.Shops;
using Lab3.Patterns.Composite;
using Lab3.Patterns.Flyweight;

namespace Lab3.Patterns.Facade;

public class BakeryFacade
{
    private readonly List<BakeryShop> shops;

    public BakeryFacade()
        : this(new IngredientTypeFactory())
    {
    }

    public BakeryFacade(IngredientTypeFactory types)
    {
        Types = types;

        shops = new List<BakeryShop>
        {
            new CookieShop(types),
            new CroissantShop(types),
            new MuffinShop(types)
        };
    }

    public IngredientTypeFactory Types { get; }

    public IReadOnlyList<BakeryShop> Shops => shops;

    public IBakedItem Order(int shopPosition, int menuPosition)
    {
        if (shopPosition < 1 || shopPosition > shops.Count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(shopPosition),
                $"The bakery has no shop at position {shopPosition}.");
        }

        return shops[shopPosition - 1].Order(menuPosition);
    }

    public GiftBox NewGiftBox(string name) => new GiftBox(name);

    public void PrintShops()
    {
        Console.WriteLine("Shops in this bakery:");

        for (int i = 0; i < shops.Count; i++)
        {
            Console.WriteLine($"  {i + 1}) {shops[i].ShopName}");
        }
    }
}