namespace Lab1;

public class ChocolateChipCookie : Cookie
{
    public override string Name => "Chocolate Chip Cookie";

    public override IReadOnlyList<string> Tools { get; } = new List<string>
    {
        "Kitchen scale",
        "Small bowl",
        "Large mixing bowl",
        "Electric hand mixer",
        "Rubber spatula",
        "Cookie sheets",
        "Parchment paper",
        "Wire cooling rack"
    };

    public override IReadOnlyList<Ingredient> DryIngredients { get; } = new List<Ingredient>
    {
        new Ingredient("All-purpose flour", 279),
        new Ingredient("Baking soda", 5),
        new Ingredient("Salt", 6)
    };

    public override IReadOnlyList<Ingredient> ButterAndSugars { get; } = new List<Ingredient>
    {
        new Ingredient("Butter, softened", 227),
        new Ingredient("Granulated sugar", 150),
        new Ingredient("Packed brown sugar", 150)
    };

    public override IReadOnlyList<Ingredient> WetIngredients { get; } = new List<Ingredient>
    {
        new Ingredient("Vanilla extract", 5),
        new Ingredient("Large eggs (2)", 100)
    };

    public override IReadOnlyList<Ingredient> MixIns { get; } = new List<Ingredient>
    {
        new Ingredient("Semi-sweet", 340)
    };

    public override int OvenTemperatureCelsius => 190; 

    public override int BakeMinutes => 10; 

    public override string ShapingInstruction =>
        "drop 1-tablespoon balls of dough onto parchment-lined cookie sheets, about 5 cm apart.";

    public override string ServingInstruction =>
        "cool on the baking sheet for 2 minutes, then move to a wire rack to cool completely.";
}
