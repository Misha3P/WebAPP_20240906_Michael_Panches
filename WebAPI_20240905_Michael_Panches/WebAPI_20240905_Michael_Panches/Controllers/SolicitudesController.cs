using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_20240905_Michael_Panches.Models;

namespace WebAPI_20240905_Michael_Panches.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitudesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SolicitudesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Solicitudes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Solicitud>>> GetSolicituds()
        {
          if (_context.Solicituds == null)
          {
              return NotFound();
          }
            return await _context.Solicituds.ToListAsync();
        }

        // GET: api/Solicitudes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Solicitud>> GetSolicitud(int id)
        {
          if (_context.Solicituds == null)
          {
              return NotFound();
          }
            var solicitud = await _context.Solicituds.FindAsync(id);

            if (solicitud == null)
            {
                return NotFound();
            }

            return solicitud;
        }

        // PUT: api/Solicitudes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSolicitud(int id, SolicitudDTO solicitudDTO)
        {
            if (id != solicitudDTO.Id)
            {
                return BadRequest();
            }

            var solicitud = await _context.Solicituds.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            // Map DTO to entity
            solicitud.ClienteId = solicitudDTO.ClienteId;
            solicitud.Monto = solicitudDTO.Monto;
            solicitud.Plazo = solicitudDTO.Plazo;
            solicitud.Estado = solicitudDTO.Estado;
            solicitud.FechaSolicitud = solicitudDTO.FechaSolicitud;

            _context.Entry(solicitud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolicitudExists(id))
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


        // POST: api/Solicitudes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // POST: api/Solicitudes
        [HttpPost]
        public async Task<ActionResult<Solicitud>> PostSolicitud(SolicitudDTO solicitudDTO)
        {
            if (_context.Solicituds == null)
            {
                return Problem("Entity set 'DatabaseContext.Solicituds' is null.");
            }

            // Map DTO to entity
            var solicitud = new Solicitud
            {
                ClienteId = solicitudDTO.ClienteId,
                Monto = solicitudDTO.Monto,
                Plazo = solicitudDTO.Plazo,
                Estado = solicitudDTO.Estado,
                FechaSolicitud = solicitudDTO.FechaSolicitud
            };

            _context.Solicituds.Add(solicitud);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSolicitud", new { id = solicitud.Id }, solicitud);
        }


        // DELETE: api/Solicitudes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSolicitud(int id)
        {
            if (_context.Solicituds == null)
            {
                return NotFound();
            }
            var solicitud = await _context.Solicituds.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }

            _context.Solicituds.Remove(solicitud);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SolicitudExists(int id)
        {
            return (_context.Solicituds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
