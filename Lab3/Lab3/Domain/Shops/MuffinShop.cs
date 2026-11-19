using Lab3.Domain.Factories;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Shops;

public class MuffinShop : BakeryShop
{
    public MuffinShop(IIngredientTypeProvider types)
        : base(types)
    {
        AddProduct("Blueberry Muffin", t => new BlueberryMuffinIngredientsFactory(t));
        AddProduct("Banana Nut Muffin", t => new BananaNutMuffinIngredientsFactory(t));
    }

    public override string ShopName => "Muffin shop";

    protected override string Category => "Muffin";
}