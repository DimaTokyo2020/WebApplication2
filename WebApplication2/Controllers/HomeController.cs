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
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public async Task<IActionResult> Home()
        {
            //ragePlaylist
            var rage = await _context.Moods
            .Include(s => s.Songs)
           .ThenInclude(e => e.Singer)
           .AsNoTracking()
           .SingleOrDefaultAsync(m => m.MoodID == "Rage");

            int size = rage.Songs.Count();
            if (rage.Songs.Count() > 0)
            {
                string PlayList = rage.Songs.ElementAt(0).SongID;
                for (int i = 1; i < size; i++)
                    PlayList += "," + (rage.Songs.ElementAt(i).SongID);
                @ViewData["ragePlaylist"] = PlayList;
            }
            //chillPlaylist
            var chill = await _context.Moods
            .Include(s => s.Songs)
           .ThenInclude(e => e.Singer)
           .AsNoTracking()
           .SingleOrDefaultAsync(m => m.MoodID == "Chill");

            size = chill.Songs.Count();
            if (chill.Songs.Count() > 0)
            {
                string PlayList = chill.Songs.ElementAt(0).SongID;
                for (int i = 1; i < size; i++)
                    PlayList += "," + (chill.Songs.ElementAt(i).SongID);
                @ViewData["chillPlaylist"] = PlayList;
            }
            //partyPlaylist
            var party = await _context.Moods
            .Include(s => s.Songs)
           .ThenInclude(e => e.Singer)
           .AsNoTracking()
           .SingleOrDefaultAsync(m => m.MoodID == "Party");

            size = party.Songs.Count();
            if (party.Songs.Count() > 0)
            {
                string PlayList = party.Songs.ElementAt(0).SongID;
                for (int i = 1; i < size; i++)
                    PlayList += "," + (party.Songs.ElementAt(i).SongID);
                @ViewData["partyPlaylist"] = PlayList;
            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
