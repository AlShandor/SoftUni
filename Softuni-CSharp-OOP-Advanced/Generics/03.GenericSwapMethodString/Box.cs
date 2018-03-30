
public class Box<T>
{
    
    public Box()
    {
        this.Value = default(T);
    }

    public Box(T value)
    {
        this.Value = value;
    }
    public override string ToString()
    {
        return $"{typeof(T).FullName}: {this.Value}";
    }

    public T Value { get; set; }
}

