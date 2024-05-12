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
    public class CondidatsController : ControllerBase
    {
        private readonly Auto_Ecole_ManegmentContext _context;

        public CondidatsController(Auto_Ecole_ManegmentContext context)
        {
            _context = context;
        }

        // GET: api/Condidats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condidat>>> GetCondidat()
        {
            return await _context.Condidat.ToListAsync();
        }

        // GET: api/Condidats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Condidat>> GetCondidat(int id)
        {
            var condidat = await _context.Condidat.FindAsync(id);

            if (condidat == null)
            {
                return NotFound();
            }

            return condidat;
        }

        // PUT: api/Condidats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCondidat(int id, Condidat condidat)
        {
            if (id != condidat.Id)
            {
                return BadRequest();
            }

            _context.Entry(condidat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CondidatExists(id))
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

        // POST: api/Condidats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Condidat>> PostCondidat(Condidat condidat)
        {
            _context.Condidat.Add(condidat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCondidat", new { id = condidat.Id }, condidat);
        }

        // DELETE: api/Condidats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCondidat(int id)
        {
            var condidat = await _context.Condidat.FindAsync(id);
            if (condidat == null)
            {
                return NotFound();
            }

            _context.Condidat.Remove(condidat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CondidatExists(int id)
        {
            return _context.Condidat.Any(e => e.Id == id);
        }
    }
}
