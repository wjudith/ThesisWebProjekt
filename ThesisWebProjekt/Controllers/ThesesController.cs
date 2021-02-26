using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThesisWebProjekt.Data;
using ThesisWebProjekt.Models;

namespace ThesisWebProjekt.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ThesesController : Controller
    {
        //Sortierung der Thesisliste!

        public enum SortCriteria
        {
            [Display(Name = "Titel")]
            Title,
            [Display(Name = "Name")]
            Name,
            [Display(Name = "Matrikelnummer")]
            StudentId,
            [Display(Name = "Thesistyp")]
            Type,
            [Display(Name = "Note")]
            Grade,
            [Display(Name = "Status")]
            Status
        }


        private readonly ThesisDBContext _context;
        private readonly UserManager<AppUser> _usermgr;

        public ThesesController(ThesisDBContext context, UserManager<AppUser> usermgr)
        {
            _context = context;
            _usermgr = usermgr;
        }






        // GET: Theses
        public async Task<IActionResult> Index(SortCriteria Sort = SortCriteria.Status)
        {
            IQueryable<Thesis> query = _context.Thesis;


            switch (Sort)
            {
                case SortCriteria.Title:
                    query = query.OrderBy(m => m.Title);
                    break;
                case SortCriteria.Name:
                    query = query.OrderBy(m => m.StudentName);
                    break;
                case SortCriteria.StudentId:
                    query = query.OrderBy(m => m.StudentId);
                    break;
                case SortCriteria.Type:
                    query = query.OrderBy(m => m.Type);
                    break;
                case SortCriteria.Grade:
                    query = query.OrderBy(m => m.Grade);
                    break;
                case SortCriteria.Status:
                    query = query.OrderBy(m => m.Status);
                    break;
            }


           
            var thesisDBContext = _context.Thesis.Include(t => t.Programme).Include(t => t.Betreuer).Include(t => t.Lehrstuhl);
            int PageTotal = await query.CountAsync();




            ViewBag.Sort = Sort;
          
            ViewBag.PageTotal = PageTotal;
        

            return View(await query.ToListAsync());
            //   return View(await thesisDBContext.ToListAsync());
        }







        // GET: Theses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis
                .Include(t => t.Programme)
                .Include(t => t.Betreuer)
                .Include(t => t.Lehrstuhl)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thesis == null)
            {
                return NotFound();
            }

            return View(thesis);
        }

        // SORTING
       

        // GET: Theses/Create
        public IActionResult Create()
        {
            ViewData["ProgrammeId"] = new SelectList(_context.Set<Programme>(), "Id", "Name");
            return View();
        }

        // POST: Theses/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Bachelor,Master,Status,StudentName,StudentEmail,StudentId,Registration,Filing,Type,Summary,Strengths,Weaknesses,Evaluation,ContentVal,LayoutVal,StructureVal,StyleVal,LiteratureVal,DifficultyVal,NoveltyVal,RichnessVal,ContentWt,LayoutWt,StructureWt,StyleWt,LiteratureWt,DifficultyWt,NoveltyWt,RichnessWt,Grade,ProgrammeId,LastModified")] Thesis thesis)
        {
            if (ModelState.IsValid)
            {
                thesis.Betreuer = await _usermgr.GetUserAsync(User);
                _context.Add(thesis);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProgrammeId"] = new SelectList(_context.Set<Programme>(), "Id", "Name", thesis.ProgrammeId);
            return View(thesis);
        }

        // GET: Theses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis.FindAsync(id);
            if (thesis == null)
            {
                return NotFound();
            }
            ViewData["ProgrammeId"] = new SelectList(_context.Set<Programme>(), "Id", "Name", thesis.ProgrammeId);
            return View(thesis);
        }

        // POST: Theses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Bachelor,Master,Status,StudentName,StudentEmail,StudentId,Registration,Filing,Type,Summary,Strengths,Weaknesses,Evaluation,ContentVal,LayoutVal,StructureVal,StyleVal,LiteratureVal,DifficultyVal,NoveltyVal,RichnessVal,ContentWt,LayoutWt,StructureWt,StyleWt,LiteratureWt,DifficultyWt,NoveltyWt,RichnessWt,Grade,ProgrammeId,LehrstuhlId")] Thesis thesis)
        {
            if (id != thesis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                int? weight = thesis.ContentWt + thesis.LayoutWt + thesis.StyleWt + thesis.StructureWt + thesis.DifficultyWt + thesis.NoveltyWt + thesis.RichnessWt + thesis.LiteratureWt; ;
                if (weight != 100)
                {
                    ModelState.AddModelError(string.Empty, "Alle Gewichtungsfaktoren müssen angegeben sein und 100% ergeben.");
                }
                else
                {
                    try
                    {
                        thesis.LastModified = DateTime.UtcNow;
                        _context.Update(thesis);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ThesisExists(thesis.Id))
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

            }
            ViewData["ProgrammeId"] = new SelectList(_context.Programme, "Id", "Name", thesis.ProgrammeId);
           
            return View(thesis);
        }

        // GET: Theses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis
                .Include(t => t.Programme)
                .Include(t => t.Betreuer)
                .Include(t => t.Lehrstuhl)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thesis == null)
            {
                return NotFound();
            }

            return View(thesis);
        }

        // POST: Theses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thesis = await _context.Thesis.FindAsync(id);
            _context.Thesis.Remove(thesis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThesisExists(int id)
        {
            return _context.Thesis.Any(e => e.Id == id);
        }
    }
}
