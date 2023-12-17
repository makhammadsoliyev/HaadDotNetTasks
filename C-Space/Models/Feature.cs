namespace C_Space.Models;

public class Feature
{
    private static int id = 0;
    public Feature()
    {
        this.Id = ++id;
    }
    public int Id { get; set; }
    public string Name { get; set; }
}
