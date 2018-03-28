
public abstract class Vehicle
{
    public double FuelQuantity { get; set; }
    public double FuelConsumption { get; set; }
    

    public Vehicle(double fuel, double consumption)
    {
        this.FuelQuantity = fuel;
        this.FuelConsumption = consumption;
    }

    public virtual void Refuel(double amountFuel)
    {
        this.FuelQuantity += amountFuel;
    }

    public abstract void Drive(double distance);

    public override string ToString()
    {
        return $"{this.GetType().Name}: {FuelQuantity:f2}";
    }
}



