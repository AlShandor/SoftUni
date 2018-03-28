using System;

public class Truck : Vehicle
{
    public Truck(double startingFuel, double consumption, double tankCapacity, double extraConsumtpion)
        : base(startingFuel, consumption, tankCapacity, extraConsumtpion)
    {
    }

    public override void Refuel(double amountFuel)
    {
        if (amountFuel > TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {amountFuel} fuel in the tank");
        }

        amountFuel *= 0.95;
        base.Refuel(amountFuel);
    }
}

