using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThesisWebProjekt.Data;
using ThesisWebProjekt.Models;

namespace ThesisWebProjekt.Controllers
{
    public class LehrstuhlController : Controller
    {
        private readonly ThesisDBContext _context;
        private readonly UserManager<AppUser> _usermgr;

        public LehrstuhlController(ThesisDBContext context, UserManager<AppUser> usermgr)
        {
            _context = context;
            _usermgr = usermgr;
        }

        // GET: Lehrstuhl
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lehrstuehle.Include(c => c.AppUsers).ToListAsync());
        }

        // GET: Lehrstuhl/Details/5
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

        // GET: Lehrstuhl/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lehrstuhl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Lehrstuhl lehrstuhl)
        {
            if (ModelState.IsValid)
            {
             //   lehrstuhl.User = await _usermgr.GetUserAsync(User);
                _context.Add(lehrstuhl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lehrstuhl);
        }

        // GET: Lehrstuhl/Edit/5
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

        // POST: Lehrstuhl/Edit/5
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

        // GET: Lehrstuhl/Delete/5
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

        // POST: Lehrstuhl/Delete/5
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
