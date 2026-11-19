using Lab3.Domain.Factories;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Shops;

public class CroissantShop : BakeryShop
{
    public CroissantShop(IIngredientTypeProvider types)
        : base(types)
    {
        AddProduct("Plain Butter Croissant", t => new ButterCroissantIngredientsFactory(t));
        AddProduct("Pain au Chocolat", t => new PainAuChocolatIngredientsFactory(t));
    }

    public override string ShopName => "Croissant shop";

    protected override string Category => "Croissant";
}