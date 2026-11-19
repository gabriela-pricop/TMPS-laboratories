using Lab3.Domain.Models;
using Lab3.Domain.Shops;
using Lab3.Patterns.Composite;
using Lab3.Patterns.Decorator;
using Lab3.Patterns.Flyweight;
using TestLab3.TestDoubles;

namespace TestLab3;

[TestFixture]
public class CompositeTests
{
    private IngredientTypeFactory types = null!;

    [SetUp]
    public void SetUp()
    {
        types = new IngredientTypeFactory();
    }

    [Test]
    public void LeafAndBox_AreUsedThroughTheSameInterface()
    {
        IBakedItem leaf = new CookieShop(types).Order(1);
        IBakedItem box = new GiftBox("Box").Add(new MuffinShop(types).Order(1));

        List<IBakedItem> items = new List<IBakedItem> { leaf, box };

        // The client reads every item the same way, with no type checks.
        foreach (IBakedItem item in items)
        {
            Assert.Multiple(() =>
            {
                Assert.That(item.Name, Is.Not.Empty);
                Assert.That(item.TotalWeightInGrams, Is.GreaterThan(0));
                Assert.That(item.TotalCalories, Is.GreaterThan(0));
                Assert.That(item.Ingredients, Is.Not.Empty);
                Assert.That(item.Describe(0), Does.Contain(item.Name));
            });
        }
    }

    [Test]
    public void Box_TotalsAreTheSumOfItsChildren()
    {
        GiftBox box = new GiftBox("Box")
            .Add(new StubBakedItem("A", 100, 300))
            .Add(new StubBakedItem("B", 250, 500));

        Assert.Multiple(() =>
        {
            Assert.That(box.TotalWeightInGrams, Is.EqualTo(350));
            Assert.That(box.TotalCalories, Is.EqualTo(800));
        });
    }

    [Test]
    public void NestedBoxes_AreSummedRecursively()
    {
        GiftBox inner = new GiftBox("Inner")
            .Add(new StubBakedItem("A", 100, 10))
            .Add(new StubBakedItem("B", 200, 20));

        GiftBox outer = new GiftBox("Outer")
            .Add(inner)
            .Add(new StubBakedItem("C", 50, 5));

        Assert.Multiple(() =>
        {
            Assert.That(outer.Items, Has.Count.EqualTo(2));
            Assert.That(outer.TotalWeightInGrams, Is.EqualTo(350));
            Assert.That(outer.TotalCalories, Is.EqualTo(35));
        });
    }

    [Test]
    public void Box_CanHoldDecoratedItems()
    {
        IBakedItem salted = new SeaSaltTopping(new StubBakedItem("A", 100, 0), types);

        GiftBox box = new GiftBox("Box").Add(salted).Add(new StubBakedItem("B", 50, 0));

        Assert.That(box.TotalWeightInGrams, Is.EqualTo(154));
    }
}