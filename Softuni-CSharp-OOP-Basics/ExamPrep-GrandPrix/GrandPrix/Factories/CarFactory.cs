
using System.Collections.Generic;
using System.Linq;

public class CarFactory
{
    private TyreFactory tyreFactory;

    public CarFactory()
    {
        this.tyreFactory = new TyreFactory();
    }

    public Car GetCar(List<string> carArgs)
    {
        int hp = int.Parse(carArgs[0]);
        double fuelAmount = double.Parse(carArgs[1]);
        Tyre tyre = tyreFactory.GetTyre(carArgs.Skip(2).ToList());

        return new Car(hp, fuelAmount, tyre);
    }
}

