
using System;
using System.Collections.Generic;
using System.Linq;

public class DriverFactory
{
    private CarFactory carFactory;

    public DriverFactory()
    {
        carFactory = new CarFactory();
    }

    public Driver GetDriver(List<string> driverArgs)
    {
        string type = driverArgs[0];
        string name = driverArgs[1];
        Car car = carFactory.GetCar(driverArgs.Skip(2).ToList());

        if (type == "Aggressive")
        {
            return new AggressiveDriver(name, car);
        }

        if (type == "Endurance")
        {
            return new EnduranceDriver(name, car);
        }

        return null;
    }
}

