﻿using System;
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
    public class ExamenController : ControllerBase
    {
        private readonly Auto_Ecole_ManegmentContext _context;

        public ExamenController(Auto_Ecole_ManegmentContext context)
        {
            _context = context;
        }

        // GET: api/Examen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Examen>>> GetExamen()
        {
            return await _context.Examen.ToListAsync();
        }

        // GET: api/Examen/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Examen>> GetExamen(int id)
        {
            var examen = await _context.Examen.FindAsync(id);

            if (examen == null)
            {
                return NotFound();
            }

            return examen;
        }

        // PUT: api/Examen/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamen(int id, Examen examen)
        {
            if (id != examen.Id)
            {
                return BadRequest();
            }

            _context.Entry(examen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamenExists(id))
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

        // POST: api/Examen
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Examen>> PostExamen(Examen examen)
        {
            _context.Examen.Add(examen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExamen", new { id = examen.Id }, examen);
        }

        // DELETE: api/Examen/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamen(int id)
        {
            var examen = await _context.Examen.FindAsync(id);
            if (examen == null)
            {
                return NotFound();
            }

            _context.Examen.Remove(examen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExamenExists(int id)
        {
            return _context.Examen.Any(e => e.Id == id);
        }
    }
}
