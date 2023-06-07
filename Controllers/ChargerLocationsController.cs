using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlueBud.Data;
using BlueBud.Models;

namespace BlueBud.Controllers
{
    public class ChargerLocationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChargerLocationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChargerLocations
        public IActionResult Reserve(int id)
        {
            var charger = _context.ChargerLocation.Find(id);
            if (charger != null)
            {
                charger.OccupationStatus = 1;
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }    
        
        public IActionResult CancelReserve(int id)
        {
            var charger = _context.ChargerLocation.Find(id);
            if (charger != null)
            {
                charger.OccupationStatus = 0;
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }  
        
        public async Task<IActionResult> Index()
        {
              return _context.ChargerLocation != null ? 
                          View(await _context.ChargerLocation.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ChargerLocation'  is null.");
        }

        // GET: ChargerLocations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ChargerLocation == null)
            {
                return NotFound();
            }

            var chargerLocations = await _context.ChargerLocation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chargerLocations == null)
            {
                return NotFound();
            }

            return View(chargerLocations);
        }

        // GET: ChargerLocations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChargerLocations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChargerName,Latitude,Longitude,OccupationStatus,ChargerType")] ChargerLocations chargerLocations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chargerLocations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chargerLocations);
        }

        // GET: ChargerLocations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ChargerLocation == null)
            {
                return NotFound();
            }

            var chargerLocations = await _context.ChargerLocation.FindAsync(id);
            if (chargerLocations == null)
            {
                return NotFound();
            }
            return View(chargerLocations);
        }

        // POST: ChargerLocations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ChargerName,Latitude,Longitude,OccupationStatus,ChargerType")] ChargerLocations chargerLocations)
        {
            if (id != chargerLocations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chargerLocations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChargerLocationsExists(chargerLocations.Id))
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
            return View(chargerLocations);
        }

        // GET: ChargerLocations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ChargerLocation == null)
            {
                return NotFound();
            }

            var chargerLocations = await _context.ChargerLocation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chargerLocations == null)
            {
                return NotFound();
            }

            return View(chargerLocations);
        }

        // POST: ChargerLocations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ChargerLocation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ChargerLocation'  is null.");
            }
            var chargerLocations = await _context.ChargerLocation.FindAsync(id);
            if (chargerLocations != null)
            {
                _context.ChargerLocation.Remove(chargerLocations);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChargerLocationsExists(int id)
        {
          return (_context.ChargerLocation?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
