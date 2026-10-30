using Lab2.Model;

namespace Lab2.Builders;

public class RecipeBuilder : IRecipeBuilder
{
    private string name = string.Empty;
    private string category = string.Empty;
    private readonly List<Ingredient> dryIngredients = new List<Ingredient>();
    private readonly List<Ingredient> fatsAndSugars = new List<Ingredient>();
    private readonly List<Ingredient> wetIngredients = new List<Ingredient>();
    private readonly List<Ingredient> flavourAdditions = new List<Ingredient>();

    public void Reset()
    {
        name = string.Empty;
        category = string.Empty;
        dryIngredients.Clear();
        fatsAndSugars.Clear();
        wetIngredients.Clear();
        flavourAdditions.Clear();
    }

    public IRecipeBuilder WithName(string name)
    {
        this.name = name;
        return this;
    }

    public IRecipeBuilder WithCategory(string category)
    {
        this.category = category;
        return this;
    }

    public IRecipeBuilder AddDryIngredients(IEnumerable<Ingredient> ingredients)
    {
        dryIngredients.AddRange(ingredients);
        return this;
    }

    public IRecipeBuilder AddFatsAndSugars(IEnumerable<Ingredient> ingredients)
    {
        fatsAndSugars.AddRange(ingredients);
        return this;
    }

    public IRecipeBuilder AddWetIngredients(IEnumerable<Ingredient> ingredients)
    {
        wetIngredients.AddRange(ingredients);
        return this;
    }

    public IRecipeBuilder AddFlavourAdditions(IEnumerable<Ingredient> ingredients)
    {
        flavourAdditions.AddRange(ingredients);
        return this;
    }

    public Recipe Build()
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidOperationException("A recipe cannot be built without a name.");
        }

        if (dryIngredients.Count == 0)
        {
            throw new InvalidOperationException($"The recipe for {name} has no dry ingredients.");
        }

        Recipe recipe = new Recipe(
            name,
            category,
            new List<Ingredient>(dryIngredients),
            new List<Ingredient>(fatsAndSugars),
            new List<Ingredient>(wetIngredients),
            new List<Ingredient>(flavourAdditions));

        Reset();

        return recipe;
    }
}