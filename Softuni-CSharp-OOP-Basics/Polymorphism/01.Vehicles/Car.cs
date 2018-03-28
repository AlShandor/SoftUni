using System;

public class Car : Vehicle
{
    private const double EXTRA_CONSUMPTION = 0.9;

    public Car(double startingFuel, double consumption) 
        : base(startingFuel, consumption)
    {
    }


    public override void Drive(double distance)
    {
        ValidateIfHasEnoughFuel(distance);
        this.FuelQuantity -= distance * (FuelConsumption + EXTRA_CONSUMPTION);
        Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
    }

    private void ValidateIfHasEnoughFuel(double distance)
    {
        if (this.FuelQuantity < distance * (FuelConsumption + EXTRA_CONSUMPTION))
        {
            throw new ArgumentException("Car needs refueling");
        }
    }
}

