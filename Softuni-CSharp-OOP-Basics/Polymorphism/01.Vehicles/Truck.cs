using System;

public class Truck : Vehicle
{
    private const double EXTRA_CONSUMPTION = 1.6;

    public Truck(double startingFuel, double consumption) 
        :base(startingFuel, consumption)
    {
    }

    public override void Refuel(double amountFuel)
    {
        amountFuel *= 0.95;
        base.Refuel(amountFuel);
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
            throw new ArgumentException("Truck needs refueling");
        }
    }
}

