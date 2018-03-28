using System;

public class Startup
{
    private const string carString = "Car";
    private const string truckString = "Truck";
    private const string busString = "Bus";
    private const string drive = "Drive";
    private const string driveEmpty = "DriveEmpty";
    private const string refuel = "Refuel";

    private const double BusExtraConsumption = 1.4;
    private const double CarExtraConsumption = 0.9;
    private const double TruckExtraConsumption = 1.6;

    public static void Main()
    {
        string[] carTokens = Console.ReadLine().Split();
        string[] truckTokens = Console.ReadLine().Split();
        string[] busTokens = Console.ReadLine().Split();

        Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]), double.Parse(carTokens[3]), CarExtraConsumption);
        Vehicle truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]), double.Parse(truckTokens[3]), TruckExtraConsumption);
        Vehicle bus = new Bus(double.Parse(busTokens[1]), double.Parse(busTokens[2]), double.Parse(busTokens[3]), BusExtraConsumption);

        int numCommands = int.Parse(Console.ReadLine());

        for (int i = 0; i < numCommands; i++)
        {
            try
            {
                string[] commandTokens = Console.ReadLine().Split();

                if (commandTokens[1] == carString)
                {
                    ExecuteVehicleCommand(car, commandTokens);
                }
                else if (commandTokens[1] == truckString)
                {
                    ExecuteVehicleCommand(truck, commandTokens);
                }
                else if (commandTokens[1] == busString)
                {
                    ExecuteVehicleCommand(bus, commandTokens);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
        Console.WriteLine(bus);
    }

    private static void ExecuteVehicleCommand(Vehicle vehicle, string[] commandTokens)
    {
        if (commandTokens[0] == drive)
        {
            vehicle.Drive(double.Parse(commandTokens[2]));
        }
        else if (commandTokens[0] == driveEmpty)
        {
            vehicle.Drive(double.Parse(commandTokens[2]), driveEmpty);
        }
        else if (commandTokens[0] == refuel)
        {
            vehicle.Refuel(double.Parse(commandTokens[2]));
        }
    }
}

