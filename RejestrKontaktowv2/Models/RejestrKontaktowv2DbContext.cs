using Microsoft.EntityFrameworkCore;

namespace RejestrKontaktowv2.Models
{
    public class RejestrKontaktowv2DbContext : DbContext
    {
        public RejestrKontaktowv2DbContext(DbContextOptions<RejestrKontaktowv2DbContext> options) : base(options) { }

        public DbSet<Osoba> Osoby { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Osoba>().HasData(
                new Osoba { id = 1, imie = "Hubert", nazwisko = "Kurowski", email = "kur@gmail.com", nr_tel = "111111111", adres = "Warszawa" },
                new Osoba { id = 2, imie = "Aleksander", nazwisko = "Barzyczak", email = "barz@gmail.com", nr_tel = "222222222", adres = "Podgorze Gazdy" },
                new Osoba { id = 3, imie = "Wiktor", nazwisko = "Bessert", email = "bess@gmail.com", nr_tel = "333333333", adres = "Ciechocinek" },
                new Osoba { id = 4, imie = "Marcin", nazwisko = "Chuchla", email = "chu@gmail.com", nr_tel = "444444444", adres = "Saperowice" },
                new Osoba { id = 5, imie = "Dawid", nazwisko = "Jasper", email = "daw@gmail.com", nr_tel = "669291965", adres = "Pabianice" }
                );
        }
    }
}
