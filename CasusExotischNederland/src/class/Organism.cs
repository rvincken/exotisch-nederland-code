namespace CasusExotischNederland;

public class Organism
{
    public int Id { get; private set; }
    public string DateFound { get; private set; }
    public string Description { get; private set; }
    public string PicturePath { get; private set; }
    public string LocationFound { get; private set; }

    public Organism(
        int id,
        string dateFound,
        string description,
        string picturePath,
        string locationFound)
    {
        Id = id;
        DateFound = dateFound;
        Description = description;
        PicturePath = picturePath;
        LocationFound = locationFound;
    }

    public override string ToString()
    {
        return $"""
                ID: {Id},
                DateFound: {DateFound}, 
                Description: {Description}
                PicturePath: {PicturePath}; 
                LocationFound: {LocationFound}
                """;
    }
}