
public class Car
{
    private string model;
    private decimal fuelAmount;
    private decimal consumptionPer1Km;
    private int distanceTravelled;

    public string Model { get; set; }
    public decimal FuelAmount { get; set; }
    public decimal ConsumptionPer1Km { get; set; }
    public int DistanceTravelled { get; set; }

    public Car(string[] carInfo)
    {
        Model = carInfo[0];
        FuelAmount = decimal.Parse(carInfo[1]);
        ConsumptionPer1Km = decimal.Parse(carInfo[2]);
    }
}
