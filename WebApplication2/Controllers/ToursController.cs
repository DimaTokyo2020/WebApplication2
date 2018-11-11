using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MoodTubeOriginal.Data;
using MoodTubeOriginal.Models;
using Microsoft.AspNetCore.Authorization;

namespace MoodTubeOriginal.Controllers
{
    public class ToursController : Controller
    {
        private readonly MusicContext _context;

        public ToursController(MusicContext context)
        {
            _context = context;
        }

        // GET: Tours
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {

            var Tours = _context.Tours.Include(s => s.Singer);


            return View(await Tours.ToListAsync());
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CountMoodID()
        {

            var CountMoodID =
                    from i in _context.Songs
                    group i by i.MoodID into g
                    select new CountMoodID
                    {
                        MoodName = g.Key,
                        Count = g.Count(),
                    };

            return View(await CountMoodID.ToListAsync());
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SongTour()
        {
            var SongTour = from o in _context.Songs
                           join v in _context.Tours
                           on o.SingerID equals v.Singer.SingerID
                           select new SongTour()
                           {

                               SongName = o.SongName,
                               MoodID = o.MoodID,
                               Genre = o.Genre,
                               Country = v.Country,
                               City = v.City,
                               When = v.When,
                           };



            return View(await SongTour.ToListAsync());
        }


        // GET: Tours/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UserTour()
        {


            var UserTours = from o in _context.AspNetUsers
                            join v in _context.Tours
                            on o.UserLocation equals v.Country
                            select new UserTours()
                            {

                                Country = v.Country,
                                City = v.City,
                                When = v.When,
                                UserName = o.UserName,
                                Singer = v.Singer,



                            };

            return View(await UserTours.ToListAsync());
        }

        // GET: Tours/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .SingleOrDefaultAsync(m => m.TourID == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // GET: Tours/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["SingerID"] = new SelectList(_context.Singers, "SingerID", "SingerID");
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourID,Country,City,SingerID,When")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tour);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SingerID"] = new SelectList(_context.Singers, "SingerID", "SingerID", tour.SingerID);

            return View(tour);
        }

        // GET: Tours/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours.SingleOrDefaultAsync(m => m.TourID == id);
            if (tour == null)
            {
                return NotFound();
            }
            ViewData["SingerID"] = new SelectList(_context.Singers, "SingerID", "SingerID", tour.SingerID);

            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TourID,Country,City,SingerID,When")] Tour tour)
        {
            if (id != tour.TourID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tour);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourExists(tour.TourID))
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
            ViewData["SingerID"] = new SelectList(_context.Singers, "SingerID", "SingerID", tour.SingerID);

            return View(tour);
        }

        // GET: Tours/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tour = await _context.Tours
                .SingleOrDefaultAsync(m => m.TourID == id);
            if (tour == null)
            {
                return NotFound();
            }

            return View(tour);
        }

        // POST: Tours/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tour = await _context.Tours.SingleOrDefaultAsync(m => m.TourID == id);
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourExists(string id)
        {
            return _context.Tours.Any(e => e.TourID == id);
        }
    }
}
