using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoodTubeOriginal.Data;
using MoodTubeOriginal.Models;
//Authorization
using Microsoft.AspNetCore.Authorization;

namespace MoodTubeOriginal.Controllers
{
    public class SongsController : Controller
    {
        private readonly MusicContext _context;

        public SongsController(MusicContext context)
        {
            _context = context;
        }

        // GET: Songs
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string sortOrder, string searchSongString, string searchSingerString, string searchGenreString, string searchMoodString)
        {
            ViewData["SongNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "SongName_desc" : "";
            ViewData["SingerNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "SingerName_desc" : "";
            ViewData["GenreSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Genre_desc" : "";
            ViewData["MoodSortParm"] = String.IsNullOrEmpty(sortOrder) ? "Mood_desc" : "";
            ViewData["SongNameFilter"] = searchSongString;
            ViewData["SingerNameFilter"] = searchSingerString;
            ViewData["GenreFilter"] = searchGenreString;
            ViewData["MoodFilter"] = searchMoodString;

            //Shows Songs with Singers name and Moods (All the virtual objects)
            var songs = _context.Songs.Include(s => s.Mood).Include(s => s.Singer);


            //Filters:

            //Song+Singer+Genre+Mood
            if (!String.IsNullOrEmpty(searchSongString) & !String.IsNullOrEmpty(searchSingerString) & !String.IsNullOrEmpty(searchGenreString) & !String.IsNullOrEmpty(searchMoodString))
            {
                var song = songs.Where(s => s.SongName.Contains(searchSongString)).Where(s => s.Singer.SingerName.Contains(searchSingerString)).Where(s => s.Genre.Contains(searchGenreString)).Where(s => s.MoodID.Contains(searchMoodString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Singer+Genre+Mood
            if (!String.IsNullOrEmpty(searchSingerString) & !String.IsNullOrEmpty(searchGenreString) & !String.IsNullOrEmpty(searchMoodString))
            {
                var song = songs.Where(s => s.Singer.SingerName.Contains(searchSingerString)).Where(s => s.Genre.Contains(searchGenreString)).Where(s => s.MoodID.Contains(searchMoodString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Song+Genre+Mood
            if (!String.IsNullOrEmpty(searchSongString) & !String.IsNullOrEmpty(searchGenreString) & !String.IsNullOrEmpty(searchMoodString))
            {
                var song = songs.Where(s => s.SongName.Contains(searchSongString)).Where(s => s.Genre.Contains(searchGenreString)).Where(s => s.MoodID.Contains(searchMoodString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Song+Singer+Mood
            if (!String.IsNullOrEmpty(searchSongString) & !String.IsNullOrEmpty(searchSingerString) & !String.IsNullOrEmpty(searchMoodString))
            {
                var song = songs.Where(s => s.SongName.Contains(searchSongString)).Where(s => s.Singer.SingerName.Contains(searchSingerString)).Where(s => s.MoodID.Contains(searchMoodString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Song+Singer+Genre
            if (!String.IsNullOrEmpty(searchSongString) & !String.IsNullOrEmpty(searchSingerString) & !String.IsNullOrEmpty(searchGenreString))
            {
                var song = songs.Where(s => s.SongName.Contains(searchSongString)).Where(s => s.Singer.SingerName.Contains(searchSingerString)).Where(s => s.Genre.Contains(searchGenreString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Genre+Mood
            if (!String.IsNullOrEmpty(searchGenreString) & !String.IsNullOrEmpty(searchMoodString))
            {
                var song = songs.Where(s => s.Genre.Contains(searchGenreString)).Where(s => s.MoodID.Contains(searchMoodString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Singer+Mood
            if (!String.IsNullOrEmpty(searchSingerString) & !String.IsNullOrEmpty(searchMoodString))
            {
                var song = songs.Where(s => s.Singer.SingerName.Contains(searchSingerString)).Where(s => s.MoodID.Contains(searchMoodString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Singer+Gener
            if (!String.IsNullOrEmpty(searchSingerString) & !String.IsNullOrEmpty(searchGenreString))
            {
                var song = songs.Where(s => s.Singer.SingerName.Contains(searchSingerString)).Where(s => s.Genre.Contains(searchGenreString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Song+Mood
            if (!String.IsNullOrEmpty(searchSongString) & !String.IsNullOrEmpty(searchMoodString))
            {
                var song = songs.Where(s => s.SongName.Contains(searchSongString)).Where(s => s.MoodID.Contains(searchMoodString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Song+Genre
            if (!String.IsNullOrEmpty(searchSongString) & !String.IsNullOrEmpty(searchGenreString))
            {
                var song = songs.Where(s => s.SongName.Contains(searchSongString)).Where(s => s.Genre.Contains(searchGenreString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Song+Singer
            if (!String.IsNullOrEmpty(searchSongString) & !String.IsNullOrEmpty(searchSingerString))
            {
                var song = songs.Where(s => s.SongName.Contains(searchSongString)).Where(s => s.Singer.SingerName.Contains(searchSingerString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Song
            if (!String.IsNullOrEmpty(searchSongString))
            {
                var song = songs.Where(s => s.SongName.Contains(searchSongString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Singer
            if (!String.IsNullOrEmpty(searchSingerString))
            {
                var songV = songs.Where(s => s.Singer.SingerName.Contains(searchSingerString));
                return View(await songV.AsNoTracking().ToListAsync());
                //Genre
            }
            if (!String.IsNullOrEmpty(searchGenreString))
            {
                var song = songs.Where(s => s.Genre.Contains(searchGenreString));
                return View(await song.AsNoTracking().ToListAsync());
            }
            //Mood
            if (!String.IsNullOrEmpty(searchMoodString))
            {
                var songV = songs.Where(s => s.Mood.MoodID.Contains(searchMoodString));
                return View(await songV.AsNoTracking().ToListAsync());
            }
            switch (sortOrder)
            {
                case "SongName_desc":
                    var song1 = songs.OrderByDescending(s => s.SongName);
                    return View(await song1.AsNoTracking().ToListAsync());
                case "SingerName_desc":
                    var song2 = songs.OrderBy(s => s.Singer.SingerName);
                    return View(await song2.AsNoTracking().ToListAsync());
                case "Genre_desc":
                    var song3 = songs.OrderBy(s => s.Genre);
                    return View(await song3.AsNoTracking().ToListAsync());
                case "Mood_desc":
                    var song4 = songs.OrderBy(s => s.MoodID);
                    return View(await song4.AsNoTracking().ToListAsync());
                default:
                    var song5 = songs.OrderBy(s => s.SongName);
                    return View(await song5.AsNoTracking().ToListAsync());
            }
            //return View(await songs.AsNoTracking().ToListAsync());

            /*
            var musicContext = _context.Songs.Include(s => s.Mood).Include(s => s.Singer);
                //return View(await musicContext.ToListAsync());

        }




        /*var musicContext = _context.Songs.Include(s => s.Mood).Include(s => s.Singer);
        return View(await musicContext.ToListAsync());
    */

        }


        // GET: Songs/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var song = await _context.Songs
                    .Include(s => s.Mood)
                    .Include(s => s.Singer)
                    .SingleOrDefaultAsync(m => m.SongID == id);
                if (song == null)
                {
                    return NotFound();
                }

                return View(song);
            }





        // GET: Songs/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["MoodID"] = new SelectList(_context.Moods, "MoodID", "MoodID");
            ViewData["SingerID"] = new SelectList(_context.Singers, "SingerID", "SingerID");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SongID,SongName,SingerID,MoodID,Genre")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MoodID"] = new SelectList(_context.Moods, "MoodID", "MoodID", song.MoodID);
            ViewData["SingerID"] = new SelectList(_context.Singers, "SingerID", "SingerID", song.SingerID);
            return View(song);
        }

        // GET: Songs/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs.SingleOrDefaultAsync(m => m.SongID == id);
            if (song == null)
            {
                return NotFound();
            }
            ViewData["MoodID"] = new SelectList(_context.Moods, "MoodID", "MoodID", song.MoodID);
            ViewData["SingerID"] = new SelectList(_context.Singers, "SingerID", "SingerID", song.SingerID);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SongID,SongName,SingerID,MoodID,Genre")] Song song)
        {
            if (id != song.SongID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.SongID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MoodID"] = new SelectList(_context.Moods, "MoodID", "MoodID", song.MoodID);
            ViewData["SingerID"] = new SelectList(_context.Singers, "SingerID", "SingerID", song.SingerID);
            return View(song);
        }

        // GET: Songs/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .Include(s => s.Mood)
                .Include(s => s.Singer)
                .SingleOrDefaultAsync(m => m.SongID == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var song = await _context.Songs.SingleOrDefaultAsync(m => m.SongID == id);
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(string id)
        {
            return _context.Songs.Any(e => e.SongID == id);
        }
    }
}
