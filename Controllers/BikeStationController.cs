using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace VeloVMONT.Controllers
{
    public class BikeStationController : Controller
    {
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