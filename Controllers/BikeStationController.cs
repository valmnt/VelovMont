using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace VeloVMONT.Controllers
{
    public class BikeStationController : Controller
    {
        private readonly Data.FavorisContext _context;

        public BikeStationController(Data.FavorisContext context) {
            _context = context;
        }
        
        private static readonly HttpClient client = new HttpClient();
        public async Task<IActionResult> Index()
        {
            var bikestations = await ProcessBikeStation();
            ViewBag.allBikeStations = bikestations.OrderBy(x => x.name );
            return View();
        }

        public async Task<IActionResult> Map()
        {
            var bikestations = await ProcessBikeStation();
            ViewBag.allBikeStations = bikestations;
            return View();
        }

        public async Task<IActionResult> Favoris()
        {
            return View(await _context.Favoris.ToListAsync());
        }

        public async Task<IActionResult> favAdd(int id)
        {
            if (id is int)
            {
                var fav = new Models.Favoris();
                fav.idFav = id;
                _context.Favoris.Add(fav);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();

        }

        public IActionResult BikeSupport()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BikeSupport([Bind("numberBike, message")] Models.SupportBike supportBike)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(supportBike);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {   
                //Log the error (uncomment ex variable name and write a log.
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(supportBike);
        }

        private static async Task<List<Models.BikeStation>> ProcessBikeStation()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var streamTask = client.GetStreamAsync("https://download.data.grandlyon.com/ws/rdata/jcd_jcdecaux.jcdvelov/all.json");
            var bikestations = await JsonSerializer.DeserializeAsync<Models.RootObject>(await streamTask);
            return bikestations.values;
        }
    }
}