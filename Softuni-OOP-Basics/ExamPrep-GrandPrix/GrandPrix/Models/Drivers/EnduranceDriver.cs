
public class EnduranceDriver : Driver
{
    public EnduranceDriver(string name, Car car)
        : base(name, car)
    {
        this.FuelConsumptionPerKm = 1.5;
        this.Speed = (car.Hp + car.Tyre.Degradation) / car.FuelAmount;
    }

    public override void CalculateSpeed()
    {
        this.Speed = (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
    }
}

