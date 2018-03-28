
public abstract class Animal
{
    protected string name;
    protected double weight;
    protected int foodEaten;
    protected double foodGrowth;

    public Animal(string name, double weight, double foodGrowth)
    {
        this.name = name;
        this.weight = weight;
        this.foodGrowth = foodGrowth;
    }

    public virtual string ProduceSound()
    {
        return "Sound!";
    }

    public virtual void Eat(Food food)
    {
        this.weight += food.Quantity * foodGrowth;

        this.foodEaten+= food.Quantity;
    }
}

