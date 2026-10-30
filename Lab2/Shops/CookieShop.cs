using Lab2.Factories;
using Lab2.Model;

namespace Lab2.Shops;

public class CookieShop : BakeryShop
{
    public override string ShopName => "Cookie shop";

    public override IReadOnlyList<string> Menu { get; } = new List<string>
    {
        "Chocolate Chip Cookie",
        "Oatmeal Raisin Cookie"
    };

    protected override IBakedGood CreateBakedGood(int menuPosition)
    {
        IRecipeIngredientsFactory ingredients = menuPosition switch
        {
            1 => new ChocolateChipCookieIngredientsFactory(),
            2 => new OatmealRaisinCookieIngredientsFactory(),
            _ => throw new ArgumentOutOfRangeException(nameof(menuPosition))
        };

        return Director.Construct(Menu[menuPosition - 1], "Cookie", ingredients);
    }
}