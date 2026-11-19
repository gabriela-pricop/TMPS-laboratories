using Lab3.Domain.Models;
using Lab3.Patterns.Composite;
using Lab3.Patterns.Decorator;
using Lab3.Patterns.Facade;
using Lab3.Patterns.Flyweight;

namespace Lab3;

class Program
{
    static void Main(string[] args)
    {
         BakeryFacade bakery = new BakeryFacade();

        Section("1. Flyweight - one ingredient type shared by every recipe");
        DemonstrateFlyweight(bakery);

        Section("2. Decorator - toppings added at run time, in any order");
        DemonstrateDecorator(bakery);

        Section("3. Composite - a box of items behaves like a single item");
        DemonstrateComposite(bakery);

        Section("4. All three patterns on one order");
        DemonstrateCombinedOrder(bakery);
    }

    private static void DemonstrateFlyweight(BakeryFacade bakery)
    {
        List<IBakedItem> everything = new List<IBakedItem>();

        for (int shop = 1; shop <= bakery.Shops.Count; shop++)
        {
            for (int product = 1; product <= bakery.Shops[shop - 1].Menu.Count; product++)
            {
                everything.Add(bakery.Order(shop, product));
            }
        }

        int ingredientEntries = everything.Sum(item => item.Ingredients.Count);

        Console.WriteLine($"Products built          : {everything.Count}");
        Console.WriteLine($"Ingredient entries      : {ingredientEntries}");
        Console.WriteLine($"Distinct shared types   : {bakery.Types.PooledTypeCount}");
        Console.WriteLine();

        IngredientType flourInCookie = everything[0]
            .Ingredients.First(i => i.Type.Name == "All-purpose flour").Type;
        IngredientType flourInMuffin = everything[4]
            .Ingredients.First(i => i.Type.Name == "All-purpose flour").Type;

        Console.WriteLine(
            "The flour of the chocolate chip cookie and the flour of the blueberry muffin");
        Console.WriteLine(
            $"are the same object: {ReferenceEquals(flourInCookie, flourInMuffin)}");
        Console.WriteLine();

        Console.WriteLine("Allergens declared once per type and read by every recipe:");

        foreach (IngredientType type in bakery.Types.PooledTypes
                     .Where(t => t.HasAllergen)
                     .OrderBy(t => t.Name))
        {
            Console.WriteLine($"  - {type.Name}: {type.Allergen}");
        }
    }

    private static void DemonstrateDecorator(BakeryFacade bakery)
    {
        IBakedItem plain = bakery.Order(1, 1);

        IBakedItem salted = new SeaSaltTopping(plain, bakery.Types);
        IBakedItem saltedAndDrizzled = new ChocolateDrizzle(salted, bakery.Types);

        Console.WriteLine($"{plain.Name}");
        Console.WriteLine($"  {plain.TotalWeightInGrams} g");
        Console.WriteLine($"{salted.Name}");
        Console.WriteLine($"  {salted.TotalWeightInGrams} g");
        Console.WriteLine($"{saltedAndDrizzled.Name}");
        Console.WriteLine($"  {saltedAndDrizzled.TotalWeightInGrams} g");
        Console.WriteLine();

        IBakedItem otherOrder = new SeaSaltTopping(
            new ChocolateDrizzle(bakery.Order(1, 1), bakery.Types),
            bakery.Types);

        Console.WriteLine("The same two toppings applied in the opposite order:");
        Console.WriteLine($"  {otherOrder.Name}");
        Console.WriteLine($"  {otherOrder.TotalWeightInGrams} g");
        Console.WriteLine();

        Console.WriteLine("Full ingredient list of the decorated cookie:");
        Console.Write(saltedAndDrizzled.Describe(1));
        Console.WriteLine();
        Console.WriteLine($"No new ingredient types were created: pool is still "
                          + $"{bakery.Types.PooledTypeCount} types.");
    }

    private static void DemonstrateComposite(BakeryFacade bakery)
    {
        GiftBox cookieBox = bakery.NewGiftBox("Cookie selection");
        cookieBox.Add(bakery.Order(1, 1));
        cookieBox.Add(bakery.Order(1, 2));

        GiftBox hamper = bakery.NewGiftBox("Weekend hamper");
        hamper.Add(cookieBox);
        hamper.Add(bakery.Order(2, 2));
        hamper.Add(bakery.Order(3, 1));

        Console.Write(hamper.Describe(0));
        Console.WriteLine();

        IBakedItem asItem = hamper;

        Console.WriteLine("Read through the component interface, a box answers like a product:");
        Console.WriteLine($"  Name            : {asItem.Name}");
        Console.WriteLine($"  Total weight    : {asItem.TotalWeightInGrams} g");
        Console.WriteLine($"  Ingredient count: {asItem.Ingredients.Count}");
        Console.WriteLine($"  Total calories  : {Math.Round(asItem.TotalCalories)} kcal");
    }

    private static void DemonstrateCombinedOrder(BakeryFacade bakery)
    {
        IBakedItem cookie = new ChocolateDrizzle(
            new SeaSaltTopping(bakery.Order(1, 1), bakery.Types),
            bakery.Types);

        IBakedItem muffin = new WalnutCoating(bakery.Order(3, 1), bakery.Types);

        GiftBox box = bakery.NewGiftBox("Gift box for two");
        box.Add(cookie);
        box.Add(muffin);

        IBakedItem wrappedBox = new ChocolateDrizzle(box, bakery.Types);

        Console.Write(wrappedBox.Describe(0));
        Console.WriteLine();
        Console.WriteLine($"Order name  : {wrappedBox.Name}");
        Console.WriteLine($"Total weight: {wrappedBox.TotalWeightInGrams} g");
        Console.WriteLine($"Shared types: {bakery.Types.PooledTypeCount}");
        Console.WriteLine();
        Console.WriteLine("The order passed through the facade, the factory method of the shop,");
        Console.WriteLine("the builder and its director, the abstract factory of the ingredients,");
        Console.WriteLine("the flyweight pool, three decorators and one composite box.");
    }

    private static void Section(string title)
    {
        Console.WriteLine();
        Console.WriteLine(new string('=', 70));
        Console.WriteLine(title);
        Console.WriteLine(new string('=', 70));
        Console.WriteLine();
    }
}