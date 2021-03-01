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
   
    public class ThesesController : Controller

    {
        private readonly ThesisDBContext _context;
        private readonly UserManager<AppUser> _usermgr;

        public ThesesController(ThesisDBContext context, UserManager<AppUser> usermgr)
        {
            _context = context;
            _usermgr = usermgr;
        }

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




          

        // GET: Theses

        public async Task<IActionResult> Index(string Search, string Filter, SortCriteria Sort = SortCriteria.Status, int Page = 1, int PageSize = 10)
        {
            IQueryable<Thesis> query = _context.Thesis;
           
            query = (Filter != null) ? query.Where(m => (m.BetreuerId == Filter)) : query;

          
            if (Filter != null)
            {
                query = query.Where(m => ((m.Studiengang.Id + " " + m.Studiengang.Name) == Filter));
            }


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


           
            var thesisDBContext = _context.Thesis.Include(t => t.Betreuer).Include(t => t.Lehrstuhl);
            int PageTotal = ((await query.CountAsync()) + PageSize - 1) / PageSize;
            Page = (Page > PageTotal) ? PageTotal : Page;
            Page = (Page < 1) ? 1 : Page;

            ViewBag.Search = Search;
            ViewBag.Filter = Filter;
            ViewBag.FilterValues = new SelectList(await _context.Thesis.Select(m => m.Betreuer).Distinct().ToListAsync());
            ViewBag.Sort = Sort;
            ViewBag.Page = Page;
            ViewBag.PageTotal = PageTotal;
            ViewBag.PageSize = PageSize;

            return View(await query.Skip(PageSize * (Page - 1)).Take(PageSize).ToListAsync());
        }








        // GET: Theses/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis
                .Include(t => t.Studiengang)
                .Include(t => t.Betreuer)
                .Include(t => t.Lehrstuhl)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (thesis == null)
            {
                return NotFound();
            }

            return View(thesis);
        }

        


        // GET: Theses/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["StudiengangId"] = new SelectList(_context.Set<Studiengang>(), "Id", "Name");
            return View();
        }

        // POST: Theses/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Bachelor,Master,Status,StudentName,StudentEmail,StudentId,Registration,Filing,Type,Summary,Strengths,Weaknesses,Evaluation,ContentVal,LayoutVal,StructureVal,StyleVal,LiteratureVal,DifficultyVal,NoveltyVal,RichnessVal,ContentWt,LayoutWt,StructureWt,StyleWt,LiteratureWt,DifficultyWt,NoveltyWt,RichnessWt,Grade,StudiengangId,LastModified,LehrstuhlId")] Thesis thesis)
        {
            if (ModelState.IsValid)
            {
                thesis.Betreuer = await _usermgr.GetUserAsync(User);
                thesis.LastModified = DateTime.Now;

                //Verknüpfung Auswahlfeld Bachelor/Master mit dem Feld Type
                if (thesis.Type == ThesisType.Bachelor)
                {
                    thesis.Bachelor = true;                    
                }
                if (thesis.Type == ThesisType.Master)
                {
                    thesis.Master = true;
                }
                _context.Add(thesis);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudiengangId"] = new SelectList(_context.Set<Studiengang>(), "Id", "Name", thesis.Studiengang);
            return View(thesis);
        }

        // GET: Theses/Edit/5
        [Authorize(Roles = "Admin")]
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
            ViewData["StudiengangId"] = new SelectList(_context.Set<Studiengang>(), "Id", "Name", thesis.Studiengang);
            return View(thesis);
        }

        // POST: Theses/Edit/5
        [Authorize(Roles = "Admin")]
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Bachelor,Master,Status,StudentName,StudentEmail,StudentId,Registration,Filing,Type,Summary,Strengths,Weaknesses,Evaluation,ContentVal,LayoutVal,StructureVal,StyleVal,LiteratureVal,DifficultyVal,NoveltyVal,RichnessVal,ContentWt,LayoutWt,StructureWt,StyleWt,LiteratureWt,DifficultyWt,NoveltyWt,RichnessWt,Grade,StudiengangId,LehrstuhlId")] Thesis thesis)
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
                        thesis.Betreuer = await _usermgr.GetUserAsync(User);
                        thesis.LastModified = DateTime.Now;
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
            ViewData["Studiengang"] = new SelectList(_context.Studiengang, "Id", "Name", thesis.Studiengang);
           
            return View(thesis);
        }






        // GET: Theses/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thesis = await _context.Thesis
                .Include(t => t.Studiengang)
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
        [Authorize(Roles = "Admin")]
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

        public async Task<IActionResult> Public()
        {
            //je nach Lehrstuhlauswahl Rückgabe?

            IQueryable<Thesis> query = _context.Thesis;
            return View(await query.ToListAsync());
        }
    }
}
