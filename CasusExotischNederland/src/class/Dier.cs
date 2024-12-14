namespace CasusExotischNederland;

public class Dier : Organisme
{
    public string Categorie { get; private set; }
    
    public Dier(
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