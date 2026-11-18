using Lab3.Domain.Factories;
using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Shops;

public class CookieShop : BakeryShop
{
    public CookieShop(IngredientTypeFactory types)
        : base(types)
    {
    }

    public override string ShopName => "Cookie shop";

    public override IReadOnlyList<string> Menu { get; } = new List<string>
    {
        "Chocolate Chip Cookie",
        "Oatmeal Raisin Cookie"
    };

    protected override IBakedItem CreateBakedItem(int menuPosition)
    {
        IRecipeIngredientsFactory ingredients = menuPosition switch
        {
            1 => new ChocolateChipCookieIngredientsFactory(Types),
            2 => new OatmealRaisinCookieIngredientsFactory(Types),
            _ => throw new ArgumentOutOfRangeException(nameof(menuPosition))
        };

        return Director.Construct(Menu[menuPosition - 1], "Cookie", ingredients);
    }
}