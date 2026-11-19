using Lab3.Domain.Models;
using Lab3.Domain.Shops;
using Lab3.Patterns.Composite;
using Lab3.Patterns.Decorator;
using Lab3.Patterns.Flyweight;
using TestLab3.TestDoubles;

namespace TestLab3;

[TestFixture]
public class DecoratorTests
{
    private IngredientTypeFactory types = null!;
    private IBakedItem plain = null!;

    [SetUp]
    public void SetUp()
    {
        types = new IngredientTypeFactory();
        plain = new StubBakedItem("Plain", 100, 200);
    }

    [Test]
    public void EachDecorator_AddsItsToppingToWeightAndName()
    {
        IBakedItem salted = new SeaSaltTopping(plain, types);
        IBakedItem drizzled = new ChocolateDrizzle(plain, types);
        IBakedItem coated = new WalnutCoating(plain, types);

        Assert.Multiple(() =>
        {
            Assert.That(salted.Name, Is.EqualTo("Plain + sea salt"));
            Assert.That(salted.TotalWeightInGrams, Is.EqualTo(104));

            Assert.That(drizzled.Name, Is.EqualTo("Plain + chocolate drizzle"));
            Assert.That(drizzled.TotalWeightInGrams, Is.EqualTo(145));

            Assert.That(coated.Name, Is.EqualTo("Plain + walnut coating"));
            Assert.That(coated.TotalWeightInGrams, Is.EqualTo(130));
        });
    }

    [Test]
    public void Decorators_StackedInAnyOrder_GiveTheSameTotals()
    {
        IBakedItem oneOrder = new WalnutCoating(new ChocolateDrizzle(new SeaSaltTopping(plain, types), types), types);
        IBakedItem otherOrder = new SeaSaltTopping(new ChocolateDrizzle(new WalnutCoating(plain, types), types), types);

        Assert.Multiple(() =>
        {
            Assert.That(otherOrder.TotalWeightInGrams, Is.EqualTo(oneOrder.TotalWeightInGrams));
            Assert.That(otherOrder.TotalWeightInGrams, Is.EqualTo(179));
            Assert.That(otherOrder.TotalCalories, Is.EqualTo(oneOrder.TotalCalories).Within(1e-9));
            Assert.That(
                otherOrder.Ingredients.Select(i => i.Type.Name),
                Is.EquivalentTo(oneOrder.Ingredients.Select(i => i.Type.Name)));
        });
    }

    [Test]
    public void Decorator_DoesNotChangeTheWrappedItem()
    {
        IBakedItem cookie = new CookieShop(types).Order(1);
        double weightBefore = cookie.TotalWeightInGrams;
        int ingredientsBefore = cookie.Ingredients.Count;

        IBakedItem decorated = new WalnutCoating(new SeaSaltTopping(cookie, types), types);

        Assert.Multiple(() =>
        {
            Assert.That(cookie.TotalWeightInGrams, Is.EqualTo(weightBefore));
            Assert.That(cookie.Ingredients, Has.Count.EqualTo(ingredientsBefore));
            Assert.That(decorated.Ingredients, Has.Count.EqualTo(ingredientsBefore + 2));
        });
    }

    [Test]
    public void Decorator_CanWrapAGiftBox()
    {
        GiftBox box = new GiftBox("Box")
            .Add(new StubBakedItem("A", 100, 0))
            .Add(new StubBakedItem("B", 100, 0));

        IBakedItem drizzledBox = new ChocolateDrizzle(box, types);

        Assert.Multiple(() =>
        {
            Assert.That(drizzledBox.Name, Is.EqualTo("Box + chocolate drizzle"));
            Assert.That(drizzledBox.TotalWeightInGrams, Is.EqualTo(245));
        });
    }
}