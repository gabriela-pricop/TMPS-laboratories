namespace Lab1;

public class Baker : IBaker
{
    private readonly Cookie cookie;

    public Baker(Cookie cookie)
    {
        this.cookie = cookie;
    }

    public void MakeBiscuitsShape()
    {
        Console.WriteLine($"Shaping the {cookie.Name}s: {cookie.ShapingInstruction}");
    }

    public void ServeBiscuits()
    {
        Console.WriteLine($"Serving the {cookie.Name}s: {cookie.ServingInstruction}");
    }
}
