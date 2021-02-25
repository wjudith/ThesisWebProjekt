using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThesisWebProjekt.Data;
using ThesisWebProjekt.Models;

namespace ThesisWebProjekt.Controllers
{
    public class LehrstuhlsController : Controller
    {
        private readonly ThesisDBContext _context;

        public LehrstuhlsController(ThesisDBContext context)
        {
            _context = context;
        }

        // GET: Lehrstuhls
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lehrstuehle.ToListAsync());
        }

        // GET: Lehrstuhls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lehrstuhl = await _context.Lehrstuehle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lehrstuhl == null)
            {
                return NotFound();
            }

            return View(lehrstuhl);
        }

        // GET: Lehrstuhls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lehrstuhls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Lehrstuhl lehrstuhl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lehrstuhl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lehrstuhl);
        }

        // GET: Lehrstuhls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lehrstuhl = await _context.Lehrstuehle.FindAsync(id);
            if (lehrstuhl == null)
            {
                return NotFound();
            }
            return View(lehrstuhl);
        }

        // POST: Lehrstuhls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Lehrstuhl lehrstuhl)
        {
            if (id != lehrstuhl.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lehrstuhl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LehrstuhlExists(lehrstuhl.Id))
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
            return View(lehrstuhl);
        }

        // GET: Lehrstuhls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lehrstuhl = await _context.Lehrstuehle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lehrstuhl == null)
            {
                return NotFound();
            }

            return View(lehrstuhl);
        }

        // POST: Lehrstuhls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lehrstuhl = await _context.Lehrstuehle.FindAsync(id);
            _context.Lehrstuehle.Remove(lehrstuhl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LehrstuhlExists(int id)
        {
            return _context.Lehrstuehle.Any(e => e.Id == id);
        }
    }
}
