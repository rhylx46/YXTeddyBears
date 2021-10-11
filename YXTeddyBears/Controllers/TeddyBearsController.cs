using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YXTeddyBears.Data;
using YXTeddyBears.Models;

namespace YXTeddyBears.Controllers
{
    public class TeddyBearsController : Controller
    {
        private readonly YXTeddyBearsContext _context;

        public TeddyBearsController(YXTeddyBearsContext context)
        {
            _context = context;
        }

        // GET: TeddyBears
        public async Task<IActionResult> Index(string teddybearManu,string searchString)
        {
            IQueryable<string> manufacturerQuery = from m in _context.TeddyBears
                                                   orderby m.Manufacturer
                                                   select m.Manufacturer;
            
            var teddybears = from m in _context.TeddyBears
                             select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                teddybears = teddybears.Where(s => s.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(teddybearManu))
            {
                teddybears = teddybears.Where(x => x.Manufacturer == teddybearManu);
            }

            var teddybearManuVM = new TeddyBearsManuViewModel
            {
                Manufacturer = new SelectList(await manufacturerQuery.Distinct().ToListAsync()),
                TeddyBears = await teddybears.ToListAsync()
            };


            return View(teddybearManuVM);
        }

        // GET: TeddyBears/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teddyBears = await _context.TeddyBears
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teddyBears == null)
            {
                return NotFound();
            }

            return View(teddyBears);
        }

        // GET: TeddyBears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeddyBears/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Color,Material,Height,Weight,Manufacturer,ImageURL")] TeddyBears teddyBears)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teddyBears);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teddyBears);
        }

        // GET: TeddyBears/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teddyBears = await _context.TeddyBears.FindAsync(id);
            if (teddyBears == null)
            {
                return NotFound();
            }
            return View(teddyBears);
        }

        // POST: TeddyBears/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Color,Material,Height,Weight,Manufacturer,ImageURL")] TeddyBears teddyBears)
        {
            if (id != teddyBears.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teddyBears);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeddyBearsExists(teddyBears.Id))
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
            return View(teddyBears);
        }

        // GET: TeddyBears/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teddyBears = await _context.TeddyBears
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teddyBears == null)
            {
                return NotFound();
            }

            return View(teddyBears);
        }

        // POST: TeddyBears/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teddyBears = await _context.TeddyBears.FindAsync(id);
            _context.TeddyBears.Remove(teddyBears);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeddyBearsExists(int id)
        {
            return _context.TeddyBears.Any(e => e.Id == id);
        }
    }
}
