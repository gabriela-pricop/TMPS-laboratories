using Lab2.Model;

namespace Lab2.Factories;

public interface IRecipeIngredientsFactory
{
    IReadOnlyList<Ingredient> CreateDryIngredients();

    IReadOnlyList<Ingredient> CreateFatsAndSugars();

    IReadOnlyList<Ingredient> CreateWetIngredients();

    IReadOnlyList<Ingredient> CreateFlavourAdditions();
}