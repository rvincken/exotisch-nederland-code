namespace CasusExotischNederland;

public class Organisme
{
    public int Id { get; private set; }
    public string DatumGevonden { get; private set; }
    public string Beschrijving { get; private set; }
    public byte[] Afbeelding { get; private set; }
    public string Locatie { get; private set; }
    public string Naam { get; private set; }
    public string Oorsprong { get; private set; }

    public Organisme(
        int id,
        string datumGevonden,
        string beschrijving,
        string afbeeldingsPad,
        string locatie,
        string naam,
        string oorsprong)
    {
        Id = id;
        DatumGevonden = datumGevonden;
        Beschrijving = beschrijving;
        Afbeelding = LaadAfbeeldingVanPad(afbeeldingsPad);
        Locatie = locatie;
        Naam = naam;
        Oorsprong = oorsprong;
    }

    public override string ToString()
    {
        return $"""
                ID: {Id}
                Naam: {Naam}
                Oorsprong: {Oorsprong}
                Datum: {DatumGevonden}
                Beschrijving: {Beschrijving}
                Locatie: {Locatie}
                """;
    }
    
    public static byte[] LaadAfbeeldingVanPad(string bestandsPad)
    {
        if (!File.Exists(bestandsPad))
        {
            throw new FileNotFoundException($"Het bestand '{bestandsPad}' bestaat niet.");
        }

        if (Path.GetExtension(bestandsPad).ToLower() != ".png")
        {
            throw new ArgumentException("Alleen PNG bestanden zijn toegestaan.");
        }

        return File.ReadAllBytes(bestandsPad);
    }
}