
public class Ferrari : ICar
{
    private string model = "488-Spider";
    private string driver;

    public Ferrari(string driver)
    {
        Driver = driver;
    }
    
    public string Model
    {
        get { return model = "488-Spider"; }
    }

    public string Driver
    {
        get { return driver; }
        set { driver = value; }
    }

    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string UseGasPedal()
    {
        return "Zadu6avam sA!";
    }
}

