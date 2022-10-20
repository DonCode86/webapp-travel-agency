using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Data;

namespace webapp_travel_agency.Controllers
{
    [Authorize]
    public class TravelPackagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelPackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TravelPackages
        public async Task<IActionResult> Index()
        {
              return View(await _context.TravelPackages.ToListAsync());
        }

        // GET: TravelPackages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TravelPackages == null)
            {
                return NotFound();
            }

            var travelPackage = await _context.TravelPackages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelPackage == null)
            {
                return NotFound();
            }

            return View(travelPackage);
        }

        // GET: TravelPackages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TravelPackages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Image,Description,DurationInNights,Price")] TravelPackage travelPackage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(travelPackage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(travelPackage);
        }

        // GET: TravelPackages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TravelPackages == null)
            {
                return NotFound();
            }

            var travelPackage = await _context.TravelPackages.FindAsync(id);
            if (travelPackage == null)
            {
                return NotFound();
            }
            return View(travelPackage);
        }

        // POST: TravelPackages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Image,Description,DurationInNights,Price")] TravelPackage travelPackage)
        {
            if (id != travelPackage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travelPackage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelPackageExists(travelPackage.Id))
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
            return View(travelPackage);
        }

        // GET: TravelPackages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TravelPackages == null)
            {
                return NotFound();
            }

            var travelPackage = await _context.TravelPackages
                .FirstOrDefaultAsync(m => m.Id == id);
            if (travelPackage == null)
            {
                return NotFound();
            }

            return View(travelPackage);
        }

        // POST: TravelPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TravelPackages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TravelPackages'  is null.");
            }
            var travelPackage = await _context.TravelPackages.FindAsync(id);
            if (travelPackage != null)
            {
                _context.TravelPackages.Remove(travelPackage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelPackageExists(int id)
        {
          return _context.TravelPackages.Any(e => e.Id == id);
        }
    }
}
