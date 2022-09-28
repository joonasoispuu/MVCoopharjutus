using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCoopkrodus.Data;
using MVCoopkrodus.Models;

namespace MVCoopkrodus.Controllers
{
    public class GDPsController : Controller
    {
        private readonly MVCoopkrodusContext _context;

        public GDPsController(MVCoopkrodusContext context)
        {
            _context = context;
        }

        // GET: GDPs
        public async Task<IActionResult> Index(string CountryRegion, string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.GDP
                                            orderby m.Region
                                            select m.Region;

            var countries = from m in _context.GDP
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                countries = countries.Where(s => s.Country.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(CountryRegion))
            {
                countries = countries.Where(x => x.Region == CountryRegion);
            }

            var CountryRegionVM = new CountryGDPViewModel
            {
                Regions = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Countries = await countries.ToListAsync()
            };
             
            return View(CountryRegionVM);
        }

        // GET: GDPs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gDP = await _context.GDP
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gDP == null)
            {
                return NotFound();
            }

            return View(gDP);
        }

        // GET: GDPs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GDPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Country,Region,EstimatebyDollar,Population,Year")] GDP gDP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gDP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gDP);
        }

        // GET: GDPs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gDP = await _context.GDP.FindAsync(id);
            if (gDP == null)
            {
                return NotFound();
            }
            return View(gDP);
        }

        // POST: GDPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Country,Region,EstimatebyDollar,Population,Year")] GDP gDP)
        {
            if (id != gDP.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gDP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GDPExists(gDP.Id))
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
            return View(gDP);
        }

        // GET: GDPs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gDP = await _context.GDP
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gDP == null)
            {
                return NotFound();
            }

            return View(gDP);
        }

        // POST: GDPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gDP = await _context.GDP.FindAsync(id);
            _context.GDP.Remove(gDP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GDPExists(int id)
        {
            return _context.GDP.Any(e => e.Id == id);
        }
    }
}
