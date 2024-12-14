namespace CasusExotischNederland;

internal class Program
{
    private static readonly string[] Provincies =
    [
        "limburg", "noord-brabant", "zeeland", "gelderland",
        "zuid-holland", "noord-holland", "utrech", "flevoland",
        "overijssel", "drenthe", "groningen", "friesland"
    ];

    private static readonly string[] Plantcategorieen =
    [
        "mossen", "varens", "naaktzadigen", "bedektzadigen", "wieren"
    ];

    private static readonly string[] Diercategorieen =
    [
        "sponzen", "neteldieren", "platwormen", "rondwormen",
        "ringwormen", "weekdieren", "geleedpotigen", "stekelhuidigen",
        "vissen", "amfibieën", "reptielen", "vogels", "zoogdieren"
    ];
    
    static void Main()
    {
        List<Organisme> waarnemingen = new List<Organisme>();
        bool blijfVragen = true;

        Console.WriteLine("EXOTISCH NEDERLAND PROGRAMMA");

        while (blijfVragen)
        {
            Console.WriteLine("\nKies een actie.");
            Console.Write($"""
                           (1. Waarneming toevoegen)
                           (2. Waarnemingen bekijken)
                           (3. Stoppen)
                           """ + "\n> ");
            string actieKeuze = Console.ReadLine();

            switch (actieKeuze)
            {
                case "1":
                {
                    Console.WriteLine("Waarneming toevoegen gekozen.");
                    waarnemingen.Add(KrijgWaarneming(waarnemingen));
                    break;
                }
                case "2":
                {
                    Console.WriteLine("Waarnemingen bekijken gekozen.");
                    break;
                }
                case "3":
                {
                    Console.WriteLine("Stoppen gekozen.");
                    blijfVragen = false;
                    break;
                }
                default:
                {
                    Console.WriteLine("Ongeldige actie gekozen.");
                    break;
                }
            }

            foreach (Organisme waarneming in waarnemingen)
            {
                Console.Write(waarneming.ToString());
            }
        }
    }

    static Organisme KrijgWaarneming(List<Organisme> waarnemingen)
    {
        int id = KrijgGeldigeId(waarnemingen);
        
        string dierOfPlant = KrijgKeuze
        (
            "Is de waarneming van een dier of plant?\n> ",
            ["dier", "plant"]
        );
        
        Console.Write("Geef de naam van de soort.\n> ");
        string naam = Console.ReadLine().ToLower();
        
        Console.Write("Geef een beschrijving van de waarneming.\n> ");
        string beschrijving = Console.ReadLine();

        string categorie;
        if (dierOfPlant == "dier")
        {
            categorie = KrijgKeuze
            (
                "Tot welke categorie hoort het dier?\n" +
                $"Kies uit: {string.Join(", ", Diercategorieen)}\n> ",
                Diercategorieen
            );
        }
        else if (dierOfPlant == "plant")
        {
            categorie = KrijgKeuze
            (
                "Tot welke categorie hoort de plant?\n" +
                $"Kies uit: {string.Join(", ", Plantcategorieen)}\n> ",
                Plantcategorieen
            );
        }
        else
        {
            throw new Exception("Onverwachte string gevonden in var plantOfDier");
        }
        
        string oorsprong = KrijgKeuze
        (
            "Is de waarneming exoot of inheems?\n> ",
            ["exoot", "inheems"]
        );
        
        string locatie = KrijgKeuze
        (
            "In welke provincie vond de waarneming plaats?\n> ",
            Provincies
        );
        
        string afbeeldingsPad = KrijgBestandsPad
        (
            "Geef een bestandspad naar de bijbehorende afbeelding.\n> ", ".png"
        );
        
        string datumGevonden = DateTime.Now.ToString("dd/MM/yyyy");
        Console.WriteLine("Datum is opgehaald uit systeemklok.");

        switch (dierOfPlant)
        {
            case "dier":
            {
                return new Dier
                (
                    id, datumGevonden, beschrijving, afbeeldingsPad,
                    locatie, naam, oorsprong, categorie
                );
            }
            case "plant":
            {
                return new Plant
                (
                    id, datumGevonden, beschrijving, afbeeldingsPad,
                    locatie, naam, oorsprong, categorie
                );
            }
            default:
            {
                throw new Exception("Ongeldige string gevonden in var plantOfDier");
            }
        }
    }

    static string KrijgKeuze(string vraag, string[] opties)
    {
        while (true)
        {
            Console.Write(vraag);
            string antwoord = Console.ReadLine().ToLower();

            if (opties.Contains(antwoord))
            {
                return antwoord;
            }

            Console.WriteLine("Ongeldige keuze.");
        }
    }

    static string KrijgBestandsPad(string vraag, string extensie)
    {
        while (true)
        {
            Console.Write(vraag);
            string pad = Console.ReadLine();

            if (!File.Exists(pad))
            {
                Console.WriteLine("Ongeldig bestandspad.");
                continue;
            }
            
            if (Path.GetExtension(pad).ToLower() != extensie)
            {
                Console.WriteLine($"Alleen bestanden die eindigen met '{extensie}' zijn toegestaan.");
                continue;
            }

            return pad;
        }
    }

    static int KrijgGeldigeId(List<Organisme> waarnemingen)
    {
        Random rnd = new Random();
        
        int id;
        while (true)
        {
            id = rnd.Next(1000000, 9999999);
            bool idExists = false;
            
            foreach (Organisme waarneming in waarnemingen)
            {
                if (waarneming.Id == id)
                {
                    idExists = true;
                }
            }

            if (!idExists) break;
        }
        return id;
    }
}