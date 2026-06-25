namespace task04;

public interface ISpaceship
{
    public void MoveForward(); 
    public void Rotate(int angle);
    public void Fire();        
    public int Speed { get; } 
    public int FirePower { get; } 
}

public class Fighter : ISpaceship
{
    public int Speed => 100;
    public int FirePower => 50;
    public void MoveForward()
    {
        Console.WriteLine("Истрибитель летит вперёд");
    }
    public void Rotate(int angle)
    {
        Console.WriteLine($"Истрибитель поварачивает на {angle} градуса/ов");
    }
    public void Fire()
    {
        Console.WriteLine("Истребитель выстреливает ракетой");
    }
}

public class Cruiser : ISpaceship
{
    public int Speed => 50;
    public int FirePower => 100;
    public void MoveForward()
    {
        Console.WriteLine("Крейсер летит вперёд");
    }
    public void Rotate(int angle)
    {
        Console.WriteLine($"Крейсер поварачивает на {angle} градуса/ов");
    }
    public void Fire()
    {
        Console.WriteLine("Крейсер выстреливает ракетой");
    }
}
