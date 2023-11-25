using Race.Classes;

while (true)
{
    Console.WriteLine("\nВыберите тип гонки:");
    Console.WriteLine("1 - Только наземный транспорт");
    Console.WriteLine("2 - Только воздушный транспорт");
    Console.WriteLine("3 - Для всех видов транспорта");
    Console.WriteLine("0 - Выключить симуляцию");
    
    if (!int.TryParse(Console.ReadLine(), out int raceType))
        continue;
    
    switch (raceType)
    {
        case 1 or 2 or 3: 
            Console.WriteLine("Задайте дистанцию гонки (ну допустим в км):");
            if (!int.TryParse(Console.ReadLine(), out int distance) || distance <= 0)
            {
                Console.WriteLine("Дарагой, ну ты зачем ошибаешься. Попробуй еще раз");
                continue;
            }
        
            List<Vehicle> vehicles = new List<Vehicle>();

            vehicles.Add(new EarthVehicle("Сапоги-скороходы", 45, 30, 10));
            vehicles.Add(new EarthVehicle("Карета-тыква", 100, 180, 30));
            vehicles.Add(new EarthVehicle("Избушка на курьих ножках", 30, 10, 15));
            vehicles.Add(new EarthVehicle("Кентавр", 85, 20, 5));

            vehicles.Add(new AirVehicle("Ступа Бабы Яги", 90, Math.Pow(distance, 2 + Math.Log(8, distance))));
            vehicles.Add(new AirVehicle("Метла", 180, Math.Pow(distance,  5 + Math.Log(5, distance))));
            vehicles.Add(new AirVehicle("Ковер-самолет", 60, Math.Pow(distance, 3 + Math.Log(6, distance))));
            vehicles.Add(new AirVehicle("Летучий корабль", 260, Math.Pow(distance, Math.Log(3, distance))));
            
        
            RaceMain race = new RaceMain(raceType, distance);
            race.AddVehiclesToRace(vehicles);
            
            break;
        
        case 0:
            Console.WriteLine("Выключаюсь...");
            return;
        
        default:
            Console.WriteLine("Поправь прицел и повтори бросок!");
            break;
    }
    
}