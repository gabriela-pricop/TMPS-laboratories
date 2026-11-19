using Lab3.Domain.Builders;
using Lab3.Domain.Factories;
using Lab3.Domain.Models;
using Lab3.Patterns.Flyweight;

namespace Lab3.Domain.Shops;

public abstract class BakeryShop
{
    private readonly List<string> menu = new List<string>();

    private readonly Dictionary<string, Func<IIngredientTypeProvider, IRecipeIngredientsFactory>> products =
        new Dictionary<string, Func<IIngredientTypeProvider, IRecipeIngredientsFactory>>();

    protected BakeryShop(IIngredientTypeProvider types)
    {
        Types = types;
        Director = new RecipeDirector(new RecipeBuilder());
    }

    public abstract string ShopName { get; }

    protected abstract string Category { get; }

    public IReadOnlyList<string> Menu => menu;

    protected IIngredientTypeProvider Types { get; }

    protected RecipeDirector Director { get; }

    public void AddProduct(
        string productName,
        Func<IIngredientTypeProvider, IRecipeIngredientsFactory> createIngredients)
    {
        if (string.IsNullOrWhiteSpace(productName))
        {
            throw new ArgumentException("A product needs a name.", nameof(productName));
        }

        ArgumentNullException.ThrowIfNull(createIngredients);

        if (products.ContainsKey(productName))
        {
            throw new InvalidOperationException(
                $"{ShopName} already sells a product named '{productName}'.");
        }

        products[productName] = createIngredients;
        menu.Add(productName);
    }

    public IBakedItem Order(int menuPosition)
    {
        if (menuPosition < 1 || menuPosition > Menu.Count)
        {
            throw new ArgumentOutOfRangeException(
                nameof(menuPosition),
                $"{ShopName} has no product at position {menuPosition}.");
        }

        return CreateBakedItem(menuPosition);
    }

    protected virtual IBakedItem CreateBakedItem(int menuPosition)
    {
        string productName = menu[menuPosition - 1];
        IRecipeIngredientsFactory ingredients = products[productName](Types);

        return Director.Construct(productName, Category, ingredients);
    }

    public void PrintMenu()
    {
        Console.WriteLine($"{ShopName}");

        for (int i = 0; i < Menu.Count; i++)
        {
            Console.WriteLine($"  {i + 1}) {Menu[i]}");
        }
    }
}