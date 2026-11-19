namespace Lab3.Patterns.Flyweight;

public interface IIngredientTypeProvider
{
    IngredientType Get(string name);
}