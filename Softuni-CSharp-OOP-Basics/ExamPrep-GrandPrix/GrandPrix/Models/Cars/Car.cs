
public class Car
{
    private const double MaxTankCapacity = 160;

    private int hp;
    private double fuelAmount;
    private Tyre tyre;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get { return hp; }
        protected set { hp = value; }
    }

    public double FuelAmount
    {
        get { return fuelAmount; }
        set
        {
            if (value > MaxTankCapacity)
            {
                fuelAmount = 160;
            }
            fuelAmount = value;
        }
    }

    public Tyre Tyre
    {
        get { return this.tyre; }
        set { this.tyre = value; }
    }
}

