using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API2;
using Microsoft.AspNetCore.Authorization;

namespace API2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PoryectosController : ControllerBase
    {
        private readonly APIContext _context;

        public PoryectosController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Poryectos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poryecto>>> GetProyectos()
        {
            return await _context.Proyectos.ToListAsync();
        }

        // GET: api/Poryectos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Poryecto>> GetPoryecto(string id)
        {
            var poryecto = await _context.Proyectos.FindAsync(id);

            if (poryecto == null)
            {
                return NotFound();
            }

            return poryecto;
        }

        // PUT: api/Poryectos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoryecto(string id, Poryecto poryecto)
        {
            if (id != poryecto.Id)
            {
                return BadRequest();
            }

            _context.Entry(poryecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoryectoExists(id))
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

        // POST: api/Poryectos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Poryecto>> PostPoryecto(Poryecto poryecto)
        {
            _context.Proyectos.Add(poryecto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PoryectoExists(poryecto.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPoryecto", new { id = poryecto.Id }, poryecto);
        }

        // DELETE: api/Poryectos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Poryecto>> DeletePoryecto(string id)
        {
            var poryecto = await _context.Proyectos.FindAsync(id);
            if (poryecto == null)
            {
                return NotFound();
            }

            _context.Proyectos.Remove(poryecto);
            await _context.SaveChangesAsync();

            return poryecto;
        }

        private bool PoryectoExists(string id)
        {
            return _context.Proyectos.Any(e => e.Id == id);
        }
    }
}
