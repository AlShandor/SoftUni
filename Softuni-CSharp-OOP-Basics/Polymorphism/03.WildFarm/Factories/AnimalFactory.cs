
public class AnimalFactory
{
    private const double Hen_Food_Growth = 0.35;
    private const double Owl_Food_Growth = 0.25;
    private const double Mouse_Food_Growth = 0.10;
    private const double Cat_Food_Growth = 0.30;
    private const double Dog_Food_Growth = 0.40;
    private const double Tiger_Food_Growth = 1.00;

    public Animal GetAnimal(string animalType, string[] animalTokens)
    {
        if (animalType == null)
        {
            return null;
        }

        switch (animalType)
        {
            case "Owl":
                return new Owl(animalTokens[1], double.Parse(animalTokens[2]), Owl_Food_Growth, double.Parse(animalTokens[3]));
                break;
            case "Hen":
                return new Hen(animalTokens[1], double.Parse(animalTokens[2]), Hen_Food_Growth, double.Parse(animalTokens[3]));
                break;
            case "Mouse":
                return new Mouse(animalTokens[1], double.Parse(animalTokens[2]), Mouse_Food_Growth, animalTokens[3]);
                break;
            case "Dog":
                return new Dog(animalTokens[1], double.Parse(animalTokens[2]), Dog_Food_Growth, animalTokens[3]);
                break;
            case "Cat":
                return new Cat(animalTokens[1], double.Parse(animalTokens[2]), Cat_Food_Growth, animalTokens[3], animalTokens[4]);
                break;
            case "Tiger":
                return new Tiger(animalTokens[1], double.Parse(animalTokens[2]), Tiger_Food_Growth, animalTokens[3], animalTokens[4]);
                break;
            default:
                return null;
                break;
        }
    }
}

