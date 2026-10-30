using Lab2.Factories;
using Lab2.Model;

namespace Lab2.Shops;

public class MuffinShop : BakeryShop
{
    public override string ShopName => "Muffin shop";

    public override IReadOnlyList<string> Menu { get; } = new List<string>
    {
        "Blueberry Muffin",
        "Banana Nut Muffin"
    };

    protected override IBakedGood CreateBakedGood(int menuPosition)
    {
        IRecipeIngredientsFactory ingredients = menuPosition switch
        {
            1 => new BlueberryMuffinIngredientsFactory(),
            2 => new BananaNutMuffinIngredientsFactory(),
            _ => throw new ArgumentOutOfRangeException(nameof(menuPosition))
        };

        return Director.Construct(Menu[menuPosition - 1], "Muffin", ingredients);
    }
}