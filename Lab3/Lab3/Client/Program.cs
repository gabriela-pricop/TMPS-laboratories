using Lab3.Domain.Models;
using Lab3.Domain.Shops;
using Lab3.Patterns.Composite;
using Lab3.Patterns.Decorator;
using Lab3.Patterns.Facade;
using Lab3.Patterns.Flyweight;

namespace Lab3;

class Program
{
    // Every topping the customer can choose. A new decorator is offered by adding one line here.
    private static readonly IReadOnlyList<(string Name, Func<IBakedItem, IIngredientTypeProvider, IBakedItem> Apply)>
        Toppings = new List<(string, Func<IBakedItem, IIngredientTypeProvider, IBakedItem>)>
        {
            ("Sea salt", (item, types) => new SeaSaltTopping(item, types)),
            ("Chocolate drizzle", (item, types) => new ChocolateDrizzle(item, types)),
            ("Walnut coating", (item, types) => new WalnutCoating(item, types))
        };

    static void Main(string[] args)
    {
        if (args.Contains("--demo"))
        {
            RunPatternDemo(new BakeryFacade());
            return;
        }

        RunInteractive(new BakeryFacade());
    }

    // ------------------------------------------------------------------
    // Interactive bakery
    // ------------------------------------------------------------------

    private static void RunInteractive(BakeryFacade bakery)
    {
        GiftBox order = bakery.NewGiftBox("My order");

        Console.WriteLine(new string('=', 70));
        Console.WriteLine("  Welcome to the Bakery");
        Console.WriteLine(new string('=', 70));

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Main menu");
            Console.WriteLine("  1) Order a product");
            Console.WriteLine("  2) Make a gift box");
            Console.WriteLine("  3) View my order");
            Console.WriteLine("  4) Run the pattern demo");
            Console.WriteLine("  0) Checkout and exit");

            switch (ReadChoice(0, 4))
            {
                case 1:
                    OrderProduct(bakery, order);
                    break;
                case 2:
                    OrderGiftBox(bakery, order);
                    break;
                case 3:
                    ShowOrder(bakery, order);
                    break;
                case 4:
                    RunPatternDemo(new BakeryFacade());
                    break;
                case 0:
                    Checkout(order);
                    return;
            }
        }
    }

    // Keeps returning to the shop list after each product; 0 at the shop list goes back to the main menu.
    private static void OrderProduct(BakeryFacade bakery, GiftBox order)
    {
        while (true)
        {
            IBakedItem? item = ChooseProduct(bakery, "");

            if (item == null)
            {
                return;
            }

            order.Add(ChooseToppings(bakery, item, ""));

            Console.WriteLine();
            Console.WriteLine("Added to your order.");
        }
    }

    private static void OrderGiftBox(BakeryFacade bakery, GiftBox order)
    {
        Console.WriteLine();
        string name = ReadText("Name of the gift box: ", "Gift box");
        GiftBox box = bakery.NewGiftBox(name);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"Add products to \"{box.Name}\" (0 = close the box)");

            IBakedItem? item = ChooseProduct(bakery, "  ");

            if (item == null)
            {
                break;
            }

            box.Add(ChooseToppings(bakery, item, "  "));
            Console.WriteLine($"  Added. Box now has {box.Items.Count} item(s).");
        }

        if (box.Items.Count == 0)
        {
            Console.WriteLine("The box is empty, so it was not added to your order.");
            return;
        }

        Console.WriteLine($"Box closed: [{box.Name}] - {box.Items.Count} item(s), {box.TotalWeightInGrams} g");

        order.Add(box);

        Console.WriteLine();
        Console.WriteLine("Added to your order.");
    }

    // Returns null when the customer goes back without choosing.
    private static IBakedItem? ChooseProduct(BakeryFacade bakery, string pad)
    {
        Console.WriteLine();
        Console.WriteLine($"{pad}Shops in this bakery:");

        for (int i = 0; i < bakery.Shops.Count; i++)
        {
            Console.WriteLine($"{pad}  {i + 1}) {bakery.Shops[i].ShopName}");
        }

        Console.WriteLine($"{pad}  0) Back");

        int shopPosition = ReadChoice(0, bakery.Shops.Count, pad);

        if (shopPosition == 0)
        {
            return null;
        }

        BakeryShop shop = bakery.Shops[shopPosition - 1];

        Console.WriteLine();
        Console.WriteLine($"{pad}{shop.ShopName}");

        for (int i = 0; i < shop.Menu.Count; i++)
        {
            Console.WriteLine($"{pad}  {i + 1}) {shop.Menu[i]}");
        }

        Console.WriteLine($"{pad}  0) Back");

        int menuPosition = ReadChoice(0, shop.Menu.Count, pad);

        if (menuPosition == 0)
        {
            return null;
        }

        IBakedItem item = bakery.Order(shopPosition, menuPosition);

        Console.WriteLine();
        Console.WriteLine($"{pad}Built: {item.Name} ({item.TotalWeightInGrams} g)");

        return item;
    }

    // Wraps the item in one decorator per chosen topping, in the order they are chosen.
    private static IBakedItem ChooseToppings(BakeryFacade bakery, IBakedItem item, string pad)
    {
        Console.WriteLine();
        Console.WriteLine($"{pad}Add a topping to {item.Name}? (0 = done)");

        for (int i = 0; i < Toppings.Count; i++)
        {
            Console.WriteLine($"{pad}  {i + 1}) {Toppings[i].Name}");
        }

        while (true)
        {
            int choice = ReadChoice(0, Toppings.Count, pad);

            if (choice == 0)
            {
                return item;
            }

            item = Toppings[choice - 1].Apply(item, bakery.Types);
            Console.WriteLine($"{pad}  -> {item.Name} ({item.TotalWeightInGrams} g)");
        }
    }

    private static void ShowOrder(BakeryFacade bakery, GiftBox order)
    {
        Console.WriteLine();

        if (order.Items.Count == 0)
        {
            Console.WriteLine("Your order is empty.");
            return;
        }

        Console.Write(order.Describe(0));
        Console.WriteLine();

        IEnumerable<string> allergens = order.Ingredients
            .Select(ingredient => ingredient.Type)
            .Where(type => type.HasAllergen)
            .Select(type => type.Allergen)
            .Distinct()
            .OrderBy(allergen => allergen);

        Console.WriteLine($"Total weight      : {order.TotalWeightInGrams} g");
        Console.WriteLine($"Total calories    : {Math.Round(order.TotalCalories)} kcal");
        Console.WriteLine($"Allergens         : {string.Join(", ", allergens)}");
        Console.WriteLine($"Ingredient entries: {order.Ingredients.Count}");
        Console.WriteLine($"Shared types      : {bakery.Types.PooledTypeCount}");
    }

    private static void Checkout(GiftBox order)
    {
        Console.WriteLine();

        if (order.Items.Count == 0)
        {
            Console.WriteLine("Nothing ordered. Goodbye!");
            return;
        }

        Console.WriteLine(
            $"Thank you! Your order of {order.Items.Count} item(s), "
            + $"{order.TotalWeightInGrams} g, is ready.");
    }

    // Keeps asking until a number in [min, max] is typed. End of input counts as 0 (back / exit).
    private static int ReadChoice(int min, int max, string pad = "")
    {
        while (true)
        {
            Console.Write($"{pad}> ");
            string? line = Console.ReadLine();

            if (line == null)
            {
                return 0;
            }

            if (int.TryParse(line.Trim(), out int choice) && choice >= min && choice <= max)
            {
                return choice;
            }

            Console.WriteLine($"{pad}Please enter a number between {min} and {max}.");
        }
    }

    private static string ReadText(string prompt, string fallback)
    {
        Console.Write(prompt);
        string? line = Console.ReadLine();

        return string.IsNullOrWhiteSpace(line) ? fallback : line.Trim();
    }

    // ------------------------------------------------------------------
    // Scripted pattern demo (option 4, or: dotnet run -- --demo)
    // ------------------------------------------------------------------

    private static void RunPatternDemo(BakeryFacade bakery)
    {
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