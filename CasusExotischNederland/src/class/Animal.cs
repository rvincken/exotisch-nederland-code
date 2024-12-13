namespace CasusExotischNederland;

public class Animal : Organism
{
    public AnimalCategory Category { get; private set; }
    
    public Animal(
        int id,
        string dateFound,
        string description,
        string picturePath,
        string locationFound,
        AnimalCategory category)
        : base(id, dateFound, description, picturePath, locationFound)
    {
        Category = category;
    }
    
    public override string ToString()
    {
        return base.ToString() + $"\nCategory: {Category}";
    }
}