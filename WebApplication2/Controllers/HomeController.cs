using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoodTubeOriginal.Models;
using MoodTubeOriginal.Data;
using Microsoft.EntityFrameworkCore;

namespace MoodTubeOriginal.Controllers
{
    public class HomeController : Controller
    {
        private readonly MusicContext _context;

        public HomeController(MusicContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public async Task<IActionResult> Home()
        {
            var mood = await _context.Moods
            .Include(s => s.Songs)
           .ThenInclude(e => e.Singer)
           .AsNoTracking()
           .SingleOrDefaultAsync(m => m.MoodID == "Rage");

            int size = mood.Songs.Count();
            if (mood.Songs.Count() > 0)
            {
                string PlayList = mood.Songs.ElementAt(0).SongID;
                for (int i = 1; i < size; i++)
                    PlayList += "," + (mood.Songs.ElementAt(i).SongID);
                @ViewData["playlist"] = PlayList;
            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
