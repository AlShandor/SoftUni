
public class Robot : IIdentifiable
{
    private string model;
    private string id;

    public Robot(string model, string id)
    {
        Model = model;
        Id = id;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
}
