namespace Lab3.Domain.Models;

public class Indent
{
    public const int Width = 2;

    public static string Of(int indentLevel) => new string(' ', indentLevel * Width);
}