using Lab3.Domain.Models;

namespace Lab3.Domain.Builders;

public interface IRecipeBuilder
{
    void Reset();

    IRecipeBuilder WithName(string name);

    IRecipeBuilder WithCategory(string category);

    IRecipeBuilder AddDryIngredients(IEnumerable<Ingredient> ingredients);

    IRecipeBuilder AddFatsAndSugars(IEnumerable<Ingredient> ingredients);

    IRecipeBuilder AddWetIngredients(IEnumerable<Ingredient> ingredients);

    IRecipeBuilder AddFlavourAdditions(IEnumerable<Ingredient> ingredients);

    Recipe Build();
}