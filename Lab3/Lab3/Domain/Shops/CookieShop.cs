using Lab3.Domain.Factories;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Shops;

public class CookieShop : BakeryShop
{
    public CookieShop(IIngredientTypeProvider types)
        : base(types)
    {
        AddProduct("Chocolate Chip Cookie", t => new ChocolateChipCookieIngredientsFactory(t));
        AddProduct("Oatmeal Raisin Cookie", t => new OatmealRaisinCookieIngredientsFactory(t));
    }

    public override string ShopName => "Cookie shop";

    protected override string Category => "Cookie";
}