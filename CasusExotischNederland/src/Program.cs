namespace CasusExotischNederland;

internal class Program
{
    static void Main()
    {
        Random rnd = new Random();
        
        // Voorbeeld van animal en plant objecten
        Animal dog = new Animal(
            rnd.Next(int.MaxValue),
            "24/12/2008",
            "Een mooie hond",
            "afbeeldingen/hond.jpg",
            "provincie-plaatsnaam",
            AnimalCategory.Mammals
        );
        Plant flower = new Plant(
            rnd.Next(int.MaxValue),
            "03/09/2015",
            "Een mooie bloem",
            "afbeeldingen/bloem.jpg",
            "provincie-plaatsnaam",
            PlantCategory.Anglosperms
        );
        
        Console.WriteLine(dog.ToString());
        Console.WriteLine(flower.ToString());
    }
}