
using System;

public abstract class Vehicle
{
    private double extraConsumption;
    private double fuelQuantity;

    public Vehicle(double fuel, double consumption, double tankCapacity, double extraConsumtpion)
    {
        this.TankCapacity = tankCapacity;
        this.FuelQuantity = fuel > TankCapacity ? 0 : fuel;
        this.FuelConsumption = consumption;
        this.ExtraConsumption = extraConsumtpion;
    }
    
    public double ExtraConsumption { get; private set; }
    public double FuelConsumption { get; set; }
    public double TankCapacity { get; set; }

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set
        {
            if (value > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {value} fuel in the tank");
            }

            fuelQuantity = value;
        }
    }

    public virtual void Refuel(double amountFuel)
    {
        if (amountFuel > TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {amountFuel} fuel in the tank");
        }

        if (amountFuel <= 0)
        {
            throw new ArgumentException("Fuel must be a positive number");
        }

        this.FuelQuantity += amountFuel;
    }

    public virtual void Drive(double distance)
    {
        if (this.FuelQuantity < distance * (FuelConsumption + ExtraConsumption))
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }
        this.FuelQuantity -= distance * (FuelConsumption + ExtraConsumption);
        Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
    }

    public virtual void Drive(double distance, string driveEmpty)
    {
        if (this.FuelQuantity < distance * FuelConsumption)
        {
            throw new ArgumentException($"{this.GetType().Name} needs refueling");
        }
        this.FuelQuantity -= distance * FuelConsumption;
        Console.WriteLine($"{this.GetType().Name} travelled {distance} km");
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}: {FuelQuantity:f2}";
    }
}



