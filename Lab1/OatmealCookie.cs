namespace Lab1;

public class OatmealCookie : Cookie
{
    public override string Name => "Oatmeal Raisin Cookie";

    public override IReadOnlyList<string> Tools { get; } = new List<string>
    {
        "Kitchen scale",
        "Large bowl",
        "Flexible spatula",
        "1-tablespoon cookie scoop",
        "Large baking sheets",
        "Parchment paper"
    };

    public override IReadOnlyList<Ingredient> DryIngredients { get; } = new List<Ingredient>
    {
        new Ingredient("All-purpose flour", 170),
        new Ingredient("Old-fashioned rolled oats", 200),
        new Ingredient("Ground cinnamon", 3),
        new Ingredient("Baking soda", 3),
        new Ingredient("Kosher salt", 6)
    };

    public override IReadOnlyList<Ingredient> ButterAndSugars { get; } = new List<Ingredient>
    {
        new Ingredient("Unsalted butter, melted and warm", 170),
        new Ingredient("Packed light brown sugar", 200),
        new Ingredient("Granulated sugar", 200)
    };

    public override IReadOnlyList<Ingredient> WetIngredients { get; } = new List<Ingredient>
    {
        new Ingredient("Large egg", 50),
        new Ingredient("Vanilla extract", 13)
    };

    public override IReadOnlyList<Ingredient> MixIns { get; } = new List<Ingredient>
    {
        new Ingredient("Raisins", 150)
    };

    public override int OvenTemperatureCelsius => 177; 

    public override int BakeMinutes => 13; 

    public override string ShapingInstruction =>
        "rest the dough 25 to 75 minutes so the oats hydrate, then scoop 1-tablespoon portions (about 30 g) onto parchment-lined sheets, 5 cm apart.";

    public override string ServingInstruction =>
        "cool completely on the baking sheet before serving.";
}
