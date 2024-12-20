namespace CasusExotischNederland;

public class Plant : Organisme
{
    public string Categorie { get; private set; }
    
    public Plant(
        int id,
        string datumGevonden,
        string beschrijving,
        string afbeeldingsPad,
        string locatie,
        string naam,
        string oorsprong,
        string categorie)
        : base(id, datumGevonden, beschrijving, afbeeldingsPad, locatie, naam, oorsprong)
    {
        Categorie = categorie;
    }

    public override string ToString()
    {
        return base.ToString() + $"\nCategorie: {Categorie}";
    }
}