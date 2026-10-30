using Lab2.Model;
using Lab2.Shops;

public class Program
{
    private static readonly IReadOnlyList<BakeryShop> Shops = new List<BakeryShop>
    {
        new CookieShop(),
        new CroissantShop(),
        new MuffinShop()
    };

    public static void Main()
    {
        Console.WriteLine("=== Bakery ===");

        while (true)
        {
            BakeryShop? shop = ChooseShop();

            if (shop == null)
            {
                break;
            }

            int menuPosition = ChooseProduct(shop);

            if (menuPosition == 0)
            {
                continue;
            }

            IBakedGood product = shop.Order(menuPosition);

            Console.WriteLine();
            product.PrintIngredients();
        }

        Console.WriteLine("Goodbye!");
    }

    private static BakeryShop? ChooseShop()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Which shop would you like to visit?");

            for (int i = 0; i < Shops.Count; i++)
            {
                Console.WriteLine($"  {i + 1}) {Shops[i].ShopName}");
            }

            Console.WriteLine("  0) Exit");
            Console.Write("Your choice: ");

            string? answer = Console.ReadLine();

            if (answer == null || answer.Trim() == "0")
            {
                return null;
            }

            if (int.TryParse(answer.Trim(), out int choice)
                && choice >= 1
                && choice <= Shops.Count)
            {
                return Shops[choice - 1];
            }

            Console.WriteLine($"Please enter a number between 0 and {Shops.Count}.");
        }
    }

    private static int ChooseProduct(BakeryShop shop)
    {
        while (true)
        {
            Console.WriteLine();
            shop.PrintMenu();
            Console.Write("Your choice: ");

            string? answer = Console.ReadLine();

            if (answer == null)
            {
                return 0;
            }

            if (int.TryParse(answer.Trim(), out int choice)
                && choice >= 0
                && choice <= shop.Menu.Count)
            {
                return choice;
            }

            Console.WriteLine($"Please enter a number between 0 and {shop.Menu.Count}.");
        }
    }
}