using Lab3.Domain.Factories;
using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Shops;

public class MuffinShop : BakeryShop
{
    public MuffinShop(IngredientTypeFactory types)
        : base(types)
    {
    }

    public override string ShopName => "Muffin shop";

    public override IReadOnlyList<string> Menu { get; } = new List<string>
    {
        "Blueberry Muffin",
        "Banana Nut Muffin"
    };

    protected override IBakedItem CreateBakedItem(int menuPosition)
    {
        IRecipeIngredientsFactory ingredients = menuPosition switch
        {
            1 => new BlueberryMuffinIngredientsFactory(Types),
            2 => new BananaNutMuffinIngredientsFactory(Types),
            _ => throw new ArgumentOutOfRangeException(nameof(menuPosition))
        };

        return Director.Construct(Menu[menuPosition - 1], "Muffin", ingredients);
    } 
}