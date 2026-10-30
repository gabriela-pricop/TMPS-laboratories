using Lab2.Factories;
using Lab2.Model;

namespace Lab2.Shops;

public class CroissantShop : BakeryShop
{
    public override string ShopName => "Croissant shop";

    public override IReadOnlyList<string> Menu { get; } = new List<string>
    {
        "Plain Butter Croissant",
        "Pain au Chocolat"
    };

    protected override IBakedGood CreateBakedGood(int menuPosition)
    {
        IRecipeIngredientsFactory ingredients = menuPosition switch
        {
            1 => new ButterCroissantIngredientsFactory(),
            2 => new PainAuChocolatIngredientsFactory(),
            _ => throw new ArgumentOutOfRangeException(nameof(menuPosition))
        };

        return Director.Construct(Menu[menuPosition - 1], "Croissant", ingredients);
    }
}