using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Auto_Ecole_Manegment.Data;
using Auto_ecole_project.Models;

namespace Auto_Ecole_Manegment.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoniteursController : ControllerBase
    {
        private readonly Auto_Ecole_ManegmentContext _context;

        public MoniteursController(Auto_Ecole_ManegmentContext context)
        {
            _context = context;
        }

        // GET: api/Moniteurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moniteur>>> GetMoniteur()
        {
            return await _context.Moniteur.ToListAsync();
        }

        // GET: api/Moniteurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Moniteur>> GetMoniteur(int id)
        {
            var moniteur = await _context.Moniteur.FindAsync(id);

            if (moniteur == null)
            {
                return NotFound();
            }

            return moniteur;
        }

        // PUT: api/Moniteurs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoniteur(int id, Moniteur moniteur)
        {
            if (id != moniteur.Id)
            {
                return BadRequest();
            }

            _context.Entry(moniteur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoniteurExists(id))
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

        // POST: api/Moniteurs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Moniteur>> PostMoniteur(Moniteur moniteur)
        {
            _context.Moniteur.Add(moniteur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoniteur", new { id = moniteur.Id }, moniteur);
        }

        // DELETE: api/Moniteurs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoniteur(int id)
        {
            var moniteur = await _context.Moniteur.FindAsync(id);
            if (moniteur == null)
            {
                return NotFound();
            }

            _context.Moniteur.Remove(moniteur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoniteurExists(int id)
        {
            return _context.Moniteur.Any(e => e.Id == id);
        }
    }
}
