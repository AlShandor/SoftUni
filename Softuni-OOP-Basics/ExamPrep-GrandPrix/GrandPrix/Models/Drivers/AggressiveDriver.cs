
public class AggressiveDriver : Driver
{
    private const double SpeedMultiplier = 1.3;

    public AggressiveDriver(string name, Car car) 
        : base(name, car)
    {
        this.FuelConsumptionPerKm = 2.7;
        this.Speed = ((car.Hp + car.Tyre.Degradation) / car.FuelAmount) * SpeedMultiplier;
    }

    public override void CalculateSpeed()
    {
        this.Speed = ((this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount) * SpeedMultiplier;
    }
}

