
public class FoodFactory
{
    public Food GetFood(string foodType, int quantity)
    {
        if (foodType == null)
        {
            return null;
        }

        switch (foodType)
        {
            case "Fruit":
                return new Fruit(quantity);
                break;
            case "Meat":
                return new Meat(quantity);
                break;
            case "Seeds":
                return new Seeds(quantity);
                break;
            case "Vegetable":
                return new Vegetable(quantity);
                break;
            default:
                return null;
                break;
        }
    }
}
