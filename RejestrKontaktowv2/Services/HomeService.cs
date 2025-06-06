using Microsoft.EntityFrameworkCore;
using RejestrKontaktowv2.Models;
using RejestrKontaktowv2.Services.Interfaces;

namespace RejestrKontaktowv2.Services
{
    public class HomeService : IHomeService
    {
        private readonly RejestrKontaktowv2DbContext _context;

        public HomeService(RejestrKontaktowv2DbContext context)
        {
            _context = context;
        }

        public async Task<List<Osoba>> zwrocListe()
        {
            return await _context.Osoby.ToListAsync();
        }

        public async Task<List<Osoba>> wyszukuj(string szukanyTekst)
        {
            var osoby = _context.Osoby.AsQueryable();

            if (!string.IsNullOrEmpty(szukanyTekst))
            {
                osoby = osoby.Where(o => o.imie.Contains(szukanyTekst) ||
                                         o.nazwisko.Contains(szukanyTekst) ||
                                         o.email.Contains(szukanyTekst) ||
                                         o.nr_tel.Contains(szukanyTekst) ||
                                         o.adres.Contains(szukanyTekst));
            }
            return await osoby.ToListAsync();
        }

        public async Task dodaj(Osoba osoba)
        {
            await _context.Osoby.AddAsync(osoba);
            await _context.SaveChangesAsync();
        }
        public async Task usun(int id)
        {
            var usunElement = await _context.Osoby.Where(x => x.id == id).ToListAsync();
            _context.Osoby.RemoveRange(usunElement);
            await _context.SaveChangesAsync();
        }

        public async Task<Osoba> zwrocOsobe(int id)
        {
            return await _context.Osoby.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task edytuj(Osoba osoba)
        {
            var edytujElement = await zwrocOsobe(osoba.id);

            if (edytujElement != null)
            {
                edytujElement.imie = osoba.imie;
                edytujElement.nazwisko = osoba.nazwisko;
                edytujElement.email = osoba.email;
                edytujElement.nr_tel = osoba.nr_tel;
                edytujElement.adres = osoba.adres;
            }

            await _context.SaveChangesAsync();
        }

    }
}
