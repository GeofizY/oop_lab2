using Race.Interfaces;

namespace Race.Classes;

public class Vehicle 
{
    public string Name { get; set; }
    public double Speed { get; set; }

    public Vehicle()
    {
        
    }
    
    public Vehicle(string name, double speed)
    {
        Name = name;
        Speed = speed;
    }
    
}