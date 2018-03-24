
using System;

public abstract class Driver
{
    private string name;
    private double totalTime;
    private Car car;
    private double fuelConsumptionPerKm;
    private double speed;

    protected Driver(string name, Car car)
    {
        this.Name = name;
        this.Car = car;
    }

    public string Name
    {
        get { return name; }
        private set { this.name = value; }
    }

    public double TotalTime
    {
        get { return totalTime; }
        set { this.totalTime = value; }
    }

    public Car Car
    {
        get { return car; }
        protected set
        {
            this.car = value;

            if (car.FuelAmount < 0)
            {
                throw new ArgumentException($"{this.Name} Out of Fuel");
            }

            if (car.Tyre.Degradation < 0)
            {
                throw new ArgumentException($"{this.Name} Blown Tyre");
            }

            if (car.Tyre.Name == "Ultrasoft" && car.Tyre.Degradation < 30)
            {
                throw new ArgumentException($"{this.Name} Blown Tyre");
            }
        }
    }

    public double FuelConsumptionPerKm
    {
        get { return fuelConsumptionPerKm; }
        protected set { this.fuelConsumptionPerKm = value; }
    }

    public double Speed
    {
        get { return speed; }
        protected set { this.speed = value; }
    }

    public abstract void CalculateSpeed();
}

