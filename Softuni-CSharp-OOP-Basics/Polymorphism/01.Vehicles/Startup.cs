using System;

public class Startup
{
    private const string carString = "Car";
    private const string truckString = "Truck";
    private const string drive = "Drive";
    private const string refuel = "Refuel";

    public static void Main()
    {
        string[] carTokens = Console.ReadLine().Split();
        string[] truckTokens = Console.ReadLine().Split();

        Vehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]));
        Vehicle truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]));


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
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        Console.WriteLine(car);
        Console.WriteLine(truck);
    }

    private static void ExecuteVehicleCommand(Vehicle vehicle, string[] commandTokens)
    {
        if (commandTokens[0] == drive)
        {
            vehicle.Drive(double.Parse(commandTokens[2]));
        }
        else if (commandTokens[0] == refuel)
        {
            vehicle.Refuel(double.Parse(commandTokens[2]));
        }
    }
}

