namespace CasusExotischNederland;

public class Plant : Organism
{
    public PlantCategory Category { get; private set; }
    
    public Plant(
        int id,
        string dateFound,
        string description,
        string picturePath,
        string locationFound,
        PlantCategory category)
        : base(id, dateFound, description, picturePath, locationFound)
    {
        Category = category;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nCategory: {Category}";
    }
}