using Race.Classes;

namespace Race.Interfaces;

public interface IRaceDirection
{
    public void StartRace();
    public bool AddToRace(Vehicle vehicle);
    public void AddVehiclesToRace(List<Vehicle> vehicle);
    

}