namespace Lab1;

public abstract class Cookie
{
    public abstract string Name { get; }

    public abstract IReadOnlyList<string> Tools { get; }

    public abstract IReadOnlyList<Ingredient> DryIngredients { get; }

    public abstract IReadOnlyList<Ingredient> ButterAndSugars { get; }

    public abstract IReadOnlyList<Ingredient> WetIngredients { get; }

    public abstract IReadOnlyList<Ingredient> MixIns { get; }

    public abstract int OvenTemperatureCelsius { get; }

    public abstract int BakeMinutes { get; }

    public abstract string ShapingInstruction { get; }

    public abstract string ServingInstruction { get; }
}
