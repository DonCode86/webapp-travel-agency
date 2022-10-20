using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapp_travel_agency.Data;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TravelPackagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private object context;

        public TravelPackagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TravelPackages
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<TravelPackage>>> GetTravelPackages()
        //{
        //    return await _context.TravelPackages.ToListAsync();
        //}

        // GET: api/TravelPackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelPackage>> GetTravelPackage(int id)
        {
            var travelPackage = await _context.TravelPackages.FindAsync(id);

            if (travelPackage == null)
            {
                return NotFound();
            }

            return travelPackage;
        }

        // PUT: api/TravelPackages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTravelPackage(int id, TravelPackage travelPackage)
        {
            if (id != travelPackage.Id)
            {
                return BadRequest();
            }

            _context.Entry(travelPackage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TravelPackageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TravelPackages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TravelPackage>> PostTravelPackage(TravelPackage travelPackage)
        {
            _context.TravelPackages.Add(travelPackage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTravelPackage", new { id = travelPackage.Id }, travelPackage);
        }

        // DELETE: api/TravelPackages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelPackage(int id)
        {
            var travelPackage = await _context.TravelPackages.FindAsync(id);
            if (travelPackage == null)
            {
                return NotFound();
            }

            _context.TravelPackages.Remove(travelPackage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TravelPackageExists(int id)
        {
            return _context.TravelPackages.Any(e => e.Id == id);
        }

        [HttpGet]
        public IActionResult GetTravelPackages(string? name)
        {
            IQueryable<TravelPackage> travelPackages;

            if (name != null)
            {
                travelPackages = _context.TravelPackages.Where(package => package.Name.ToLower().Contains(name.ToLower()));
            }
            else
            {
                travelPackages = _context.TravelPackages;
            }

            return Ok(travelPackages.ToList<TravelPackage>());
        }
    }
}
