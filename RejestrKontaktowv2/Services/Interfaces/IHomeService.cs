using RejestrKontaktowv2.Models;

namespace RejestrKontaktowv2.Services.Interfaces
{
    public interface IHomeService
    {
        Task<List<Osoba>> zwrocListe();
        Task<List<Osoba>> wyszukuj(string szukanyTekst);
        Task dodaj(Osoba osoba);
        Task usun(int id);
        Task edytuj(Osoba osoba);
        Task<Osoba> zwrocOsobe(int id);
    }
}