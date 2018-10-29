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
    public class MoodsController : Controller
    {
        private readonly MusicContext _context;

        public MoodsController(MusicContext context)
        {
            _context = context;
        }



        // GET: Moods

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moods.ToListAsync());
        }


        // GET: Moods/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

                var mood = await _context.Moods
            .Include(s => s.Songs)
           .ThenInclude(e => e.Singer)
           .AsNoTracking()
           .SingleOrDefaultAsync(m => m.MoodID == id);

            /* var mood = await _context.Moods
                 .FirstOrDefaultAsync(m => m.MoodID == id);*/


            if (mood == null)
            {
                return NotFound();
            }

            


           //mood.Songs.OrderBy(s => s.SongName);

            return View(mood);
        }






        // GET: Moods/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
    {
        return View();
    }

        // POST: Moods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MoodID")] Mood mood)
    {

        try
        {
            if (ModelState.IsValid)
            {
                _context.Add(mood);
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
        return View(mood);
    }

        // GET: Moods/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var mood = await _context.Moods.FindAsync(id);
        if (mood == null)
        {
            return NotFound();
        }
        return View(mood);
    }

        // POST: Moods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("MoodID")] Mood mood)
    {
        if (id != mood.MoodID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(mood);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoodExists(mood.MoodID))
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
        return View(mood);
    }

        // GET: Moods/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var mood = await _context.Moods
            .FirstOrDefaultAsync(m => m.MoodID == id);
        if (mood == null)
        {
            return NotFound();
        }

        return View(mood);
    }

        // POST: Moods/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var mood = await _context.Moods.FindAsync(id);
        _context.Moods.Remove(mood);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MoodExists(string id)
    {
        return _context.Moods.Any(e => e.MoodID == id);
    }
}
}
