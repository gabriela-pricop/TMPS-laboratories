namespace Lab1;

public class Oven : IOven
{
    private readonly Cookie cookie;
    private bool isOn;

    public Oven(Cookie cookie)
    {
        this.cookie = cookie;
    }

    public void StartOven()
    {
        isOn = true;
        Console.WriteLine($"Preheating the oven to {cookie.OvenTemperatureCelsius} °C.");
    }

    public void Bake()
    {
        if (!isOn)
        {
            Console.WriteLine("The oven is off. Start the oven before baking.");
            return;
        }

        Console.WriteLine($"Baking the {cookie.Name}s for {cookie.BakeMinutes} minutes, until golden brown around the edges.");
    }

    public void StopOven()
    {
        isOn = false;
        Console.WriteLine("Switching the oven off.");
    }
}
