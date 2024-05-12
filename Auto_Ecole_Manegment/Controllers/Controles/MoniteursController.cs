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
    public class MoniteursController : Controller
    {
        private readonly Auto_Ecole_ManegmentContext _context;

        public MoniteursController(Auto_Ecole_ManegmentContext context)
        {
            _context = context;
        }

        // GET: Moniteurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Moniteur.ToListAsync());
        }

        // GET: Moniteurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moniteur = await _context.Moniteur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moniteur == null)
            {
                return NotFound();
            }

            return View(moniteur);
        }

        // GET: Moniteurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Moniteurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Salaire,Email,Password,Heure_Effectue")] Moniteur moniteur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(moniteur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(moniteur);
        }

        // GET: Moniteurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moniteur = await _context.Moniteur.FindAsync(id);
            if (moniteur == null)
            {
                return NotFound();
            }
            return View(moniteur);
        }

        // POST: Moniteurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Salaire,Email,Password,Heure_Effectue")] Moniteur moniteur)
        {
            if (id != moniteur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(moniteur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoniteurExists(moniteur.Id))
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
            return View(moniteur);
        }

        // GET: Moniteurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var moniteur = await _context.Moniteur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (moniteur == null)
            {
                return NotFound();
            }

            return View(moniteur);
        }

        // POST: Moniteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var moniteur = await _context.Moniteur.FindAsync(id);
            if (moniteur != null)
            {
                _context.Moniteur.Remove(moniteur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MoniteurExists(int id)
        {
            return _context.Moniteur.Any(e => e.Id == id);
        }
    }
}
