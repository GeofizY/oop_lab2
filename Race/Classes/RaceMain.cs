using System.Collections;
using Race.Interfaces;

namespace Race.Classes;

public class RaceMain : IRaceDirection
{
    public List<Vehicle> Participants { get; set; }
    public int RaceType { get; set; }
    public int Distance { get; set; }
    public RaceMain()
    {
        Participants = new List<Vehicle>();
    }

    public RaceMain(int raceType) : this()
    {
        RaceType = raceType;
    }
    public RaceMain(int raceType, int distance) : this(raceType)
    {
        Distance = distance;
    }

    public void StartRace()
    {
        var leaderTable = new SortedDictionary<double, Vehicle>();
        foreach (var vehicle in Participants)
        {
            if (vehicle is AirVehicle)
            {
                AirVehicle airVehicle;
                airVehicle = vehicle as AirVehicle;
                leaderTable.Add(airVehicle.GetTime(Distance), vehicle);

            } else if (vehicle is EarthVehicle)
            {
                EarthVehicle earthVehicle;
                earthVehicle = vehicle as EarthVehicle;
                leaderTable.Add(earthVehicle.GetTime(Distance), vehicle);
            }

        }
        
        int i = 1;
        string winer = null;
        foreach (var leader in leaderTable)
        {
            if (i == 1)
            {
                winer = leader.Value.Name;
            }
            i++;
        }
        Console.WriteLine($"И победителем становисяяяяяяя: {winer}\n");
    }

    public void AddVehiclesToRace(List<Vehicle> vehicles)
    {
        while (true)
        {
            Console.WriteLine("Выберите участников гонки:");
            Console.WriteLine("0 - Настарт Внимание Марш");
            for (int i = 0; i < vehicles.Count; i++)
            {
                Console.WriteLine($"{i+1}) {vehicles[i].Name}");
            }

            
            int.TryParse(Console.ReadLine(), out int choice);
            choice--;
            
            if (choice >= vehicles.Count)
                continue;
            if (choice == -1)
            {
                StartRace();
                return;
            }

            
            bool isAdded = AddToRace(vehicles[choice]);
            if (isAdded)
                vehicles.Remove(vehicles[choice]);
            else
            {
                Console.WriteLine("Ай-ай-ай, а так нельзя. Выбранный участник не может соревноваться в этом типе гонок");
            }
        }
    }

    public bool AddToRace(Vehicle vehicle)
    {
        switch (RaceType)
        {
            case 1:
                if (vehicle is EarthVehicle)
                {
                    Participants.Add(vehicle);
                    return true;
                } 
                return false;
            
            case 2:
                if (vehicle is AirVehicle)
                {
                    Participants.Add(vehicle);
                    return true;
                }
                return false;
            
            case 3:
                Participants.Add(vehicle);
                return true;
            
            default:
                return false;

        }
    }
    
}