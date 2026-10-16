namespace Lab1;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("=== Cookie Kitchen ===");

        while (true)
        {
            Cookie cookie = ChooseCookie();
            if (cookie == null)
            {
                break;
            }

            MakeCookies(cookie);
        }

        Console.WriteLine("Goodbye!");
    }

    private static Cookie ChooseCookie()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Which cookies would you like to bake?");
            Console.WriteLine("  1) Chocolate Chip Cookies");
            Console.WriteLine("  2) Oatmeal Raisin Cookies");
            Console.WriteLine("  0) Exit");
            Console.Write("Your choice: ");

            switch (Console.ReadLine()?.Trim())
            {
                case "1":
                    return new ChocolateChipCookie();
                case "2":
                    return new OatmealCookie();
                case "0":
                case null:
                    return null;
                default:
                    Console.WriteLine("Please enter 1, 2 or 0.");
                    break;
            }
        }
    }

    private static void MakeCookies(Cookie cookie)
    {
        IPreparation preparation = new Preparer(cookie);
        ICombineIngredients mixer = new Mixer(cookie);
        IBaker baker = new Baker(cookie);
        IOven oven = new Oven(cookie);

        Console.WriteLine();
        Console.WriteLine($"--- Making {cookie.Name}s ---");

        preparation.PrepareIngredients();
        preparation.PrepareTools();

        Console.WriteLine();
        mixer.MixDryIngredients();
        mixer.MixButterSugars();
        mixer.MixAllIngredients();
        mixer.AddMixIns();

        Console.WriteLine();
        baker.MakeBiscuitsShape();

        oven.StartOven();
        oven.Bake();
        oven.StopOven();

        baker.ServeBiscuits();
    }
}
