using Lab2.Factories;
using Lab2.Model;

namespace Lab2.Builders;

public class RecipeDirector
{
    private readonly IRecipeBuilder builder;

    public RecipeDirector(IRecipeBuilder builder)
    {
        this.builder = builder;
    }

    public Recipe Construct(string name, string category, IRecipeIngredientsFactory ingredients)
    {
        builder.Reset();

        return builder
            .WithName(name)
            .WithCategory(category)
            .AddDryIngredients(ingredients.CreateDryIngredients())
            .AddFatsAndSugars(ingredients.CreateFatsAndSugars())
            .AddWetIngredients(ingredients.CreateWetIngredients())
            .AddFlavourAdditions(ingredients.CreateFlavourAdditions())
            .Build();
    }
}