using System.Reflection;
using Lab3.Domain.Models;
using Lab3.Domain.Shops;
using Lab3.Patterns.Flyweight;

namespace TestLab3;

[TestFixture]
public class FlyweightTests
{
    private IngredientTypeFactory types = null!;

    [SetUp]
    public void SetUp()
    {
        types = new IngredientTypeFactory();
    }

    [Test]
    public void Get_SameName_ReturnsSameInstance()
    {
        IngredientType first = types.Get("All-purpose flour");
        IngredientType second = types.Get("All-purpose flour");

        Assert.That(second, Is.SameAs(first));
    }

    [Test]
    public void IntrinsicState_CannotBeChangedOrCreatedOutsideTheFactory()
    {
        PropertyInfo[] properties = typeof(IngredientType).GetProperties();
        ConstructorInfo[] publicConstructors = typeof(IngredientType).GetConstructors();

        Assert.Multiple(() =>
        {
            Assert.That(properties.Where(p => p.CanWrite), Is.Empty, "IngredientType must be immutable");
            Assert.That(publicConstructors, Is.Empty, "IngredientType must only be created by the factory");
        });
    }

    [Test]
    public void ExtrinsicState_LivesInIngredient_NotInTheSharedType()
    {
        IngredientType flour = types.Get("All-purpose flour");

        Ingredient small = new Ingredient(flour, 100);
        Ingredient large = new Ingredient(flour, 250, "sifted");

        Assert.Multiple(() =>
        {
            Assert.That(large.Type, Is.SameAs(small.Type));
            Assert.That(small.WeightInGrams, Is.EqualTo(100));
            Assert.That(large.WeightInGrams, Is.EqualTo(250));
            Assert.That(small.Calories, Is.EqualTo(364).Within(1e-9));
            Assert.That(large.Calories, Is.EqualTo(910).Within(1e-9));
        });
    }

    [Test]
    public void RecipesFromDifferentShops_ShareTheSameIngredientTypeInstance()
    {
        IBakedItem cookie = new CookieShop(types).Order(1);
        IBakedItem muffin = new MuffinShop(types).Order(1);

        IngredientType flourInCookie = cookie.Ingredients.First(i => i.Type.Name == "All-purpose flour").Type;
        IngredientType flourInMuffin = muffin.Ingredients.First(i => i.Type.Name == "All-purpose flour").Type;

        Assert.That(flourInMuffin, Is.SameAs(flourInCookie));
    }
}