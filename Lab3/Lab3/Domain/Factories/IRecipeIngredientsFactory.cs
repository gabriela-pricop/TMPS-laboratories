using Lab3.Domain.Models;

namespace Lab3.Domain.Factories;

public interface IRecipeIngredientsFactory
{
    IReadOnlyList<Ingredient> CreateDryIngredients();

    IReadOnlyList<Ingredient> CreateFatsAndSugars();

    IReadOnlyList<Ingredient> CreateWetIngredients();

    IReadOnlyList<Ingredient> CreateFlavourAdditions();
}