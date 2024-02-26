namespace EsercizioU5W1D1.Models
{
    public class Dipendente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string CodiceFiscale { get; set; }
        public bool Sposato { get; set; }
        public int FigliACarico { get; set; }
        public string Mansione { get; set; }

        public Dipendente() { }

        public Dipendente(int id, string nome, string cognome, string indirizzo, string codiceFiscale, bool sposato, int figliACarico, string mansione)
        {
            Id = id;
            Nome = nome;
            Cognome = cognome;
            Indirizzo = indirizzo;
            CodiceFiscale = codiceFiscale;
            Sposato = sposato;
            FigliACarico = figliACarico;
            Mansione = mansione;
        }
    }
}