namespace Lab3.Patterns.Flyweight;

public class IngredientTypeFactory
{
    private static readonly IReadOnlyDictionary<string, (double Calories, string Allergen)> KnownIngredients =
        new Dictionary<string, (double, string)>(StringComparer.OrdinalIgnoreCase)
        {
            ["All-purpose flour"] = (364, "Gluten"),
            ["Bread flour"] = (361, "Gluten"),
            ["Rolled oats"] = (389, "Gluten"),
            ["Baking soda"] = (0, ""),
            ["Baking powder"] = (53, ""),
            ["Salt"] = (0, ""),
            ["Ground cinnamon"] = (247, ""),
            ["Unsalted butter"] = (717, "Milk"),
            ["Granulated sugar"] = (387, ""),
            ["Brown sugar"] = (380, ""),
            ["Caster sugar"] = (387, ""),
            ["Large eggs"] = (143, "Egg"),
            ["Vanilla extract"] = (288, ""),
            ["Whole milk"] = (61, "Milk"),
            ["Water"] = (0, ""),
            ["Fresh yeast"] = (105, ""),
            ["Dried yeast"] = (325, ""),
            ["Semi-sweet chocolate chips"] = (480, "Milk"),
            ["Dark chocolate"] = (598, "Milk"),
            ["Raisins"] = (299, ""),
            ["Blueberries"] = (57, ""),
            ["Walnuts"] = (654, "Nuts"),
            ["Bananas"] = (89, "")
        };

    private readonly Dictionary<string, IngredientType> pool =
        new Dictionary<string, IngredientType>(StringComparer.OrdinalIgnoreCase);

    public IngredientType Get(string name)
    {
        if (pool.TryGetValue(name, out IngredientType? pooled))
        {
            return pooled;
        }

        if (!KnownIngredients.TryGetValue(name, out (double Calories, string Allergen) data))
        {
            throw new ArgumentException(
                $"'{name}' is not a known ingredient of this bakery.",
                nameof(name));
        }

        IngredientType created = new IngredientType(name, data.Calories, data.Allergen);
        pool[name] = created;

        return created;
    }

    public int PooledTypeCount => pool.Count;

    public IReadOnlyCollection<IngredientType> PooledTypes => pool.Values.ToList();

    public static int KnownIngredientCount => KnownIngredients.Count;
}