using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Auto_Ecole_Manegment.Data;
using Auto_ecole_project.Models;

namespace Auto_Ecole_Manegment.Controllers.Controles
{
    public class CondidatsController : Controller
    {
        private readonly Auto_Ecole_ManegmentContext _context;

        public CondidatsController(Auto_Ecole_ManegmentContext context)
        {
            _context = context;
        }

        // GET: Condidats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Condidat.ToListAsync());
        }

        // GET: Condidats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condidat = await _context.Condidat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condidat == null)
            {
                return NotFound();
            }

            return View(condidat);
        }

        // GET: Condidats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Condidats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Age,Email,Password,Cin,Etat_Condidat")] Condidat condidat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(condidat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(condidat);
        }

        // GET: Condidats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condidat = await _context.Condidat.FindAsync(id);
            if (condidat == null)
            {
                return NotFound();
            }
            return View(condidat);
        }

        // POST: Condidats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Age,Email,Password,Cin,Etat_Condidat")] Condidat condidat)
        {
            if (id != condidat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(condidat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CondidatExists(condidat.Id))
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
            return View(condidat);
        }

        // GET: Condidats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var condidat = await _context.Condidat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (condidat == null)
            {
                return NotFound();
            }

            return View(condidat);
        }

        // POST: Condidats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var condidat = await _context.Condidat.FindAsync(id);
            if (condidat != null)
            {
                _context.Condidat.Remove(condidat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CondidatExists(int id)
        {
            return _context.Condidat.Any(e => e.Id == id);
        }
    }
}
