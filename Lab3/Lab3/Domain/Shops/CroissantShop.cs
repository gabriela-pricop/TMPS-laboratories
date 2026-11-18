using Lab3.Domain.Factories;
using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Shops;

public class CroissantShop : BakeryShop
{
    public CroissantShop(IngredientTypeFactory types)
        : base(types)
    {
    }

    public override string ShopName => "Croissant shop";

    public override IReadOnlyList<string> Menu { get; } = new List<string>
    {
        "Plain Butter Croissant",
        "Pain au Chocolat"
    };

    protected override IBakedItem CreateBakedItem(int menuPosition)
    {
        IRecipeIngredientsFactory ingredients = menuPosition switch
        {
            1 => new ButterCroissantIngredientsFactory(Types),
            2 => new PainAuChocolatIngredientsFactory(Types),
            _ => throw new ArgumentOutOfRangeException(nameof(menuPosition))
        };

        return Director.Construct(Menu[menuPosition - 1], "Croissant", ingredients);
    }
}