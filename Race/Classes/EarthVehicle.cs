namespace Race.Classes;

public class EarthVehicle : Vehicle
{
    public int ChillTime { get; set;}
    public int ChillDuration { get; set; }
    
    public EarthVehicle(string name, double speed, int chillTime, int chillDuration) : base(name, speed)
    {
        ChillTime = chillTime;
        ChillDuration = chillDuration;
    }
    
    public double GetTime(int distance)
    {
        double time = distance / Speed;

        int chillCount = (int) Math.Floor(time / ChillTime);

        for (int i = 1; i <= chillCount; i++)
        {
            time += ChillDuration * Math.Sqrt(i);
        }
        
        return time;

    }
}