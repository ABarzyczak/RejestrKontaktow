using Microsoft.AspNetCore.Mvc;
using RejestrKontaktowv2.Models;
using RejestrKontaktowv2.Services.Interfaces;
using System.Diagnostics;

namespace RejestrKontaktowv2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;
        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Filtrowani = await _homeService.zwrocListe();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Szukaj(string szukanyTekst)
        {
            ViewBag.Filtrowani = await _homeService.wyszukuj(szukanyTekst);
            ViewBag.SzukanyTekst = szukanyTekst;
            return View("Index");
        }

        public async Task<IActionResult> Dodaj()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Dodaj(Osoba osoba)
        {
            await _homeService.dodaj(osoba);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Usun(int id)
        {
            await _homeService.usun(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edytuj(int id)
        {
            var osoba = await _homeService.zwrocOsobe(id);
            return View(osoba);
        }
        [HttpPost]
        public async Task<IActionResult> Edytuj(Osoba osoba)
        {
            await _homeService.edytuj(osoba);
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
