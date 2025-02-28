using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P01DAW__2023PA651_2022IV650__Reservas.Models;
using System.Collections.Generic;
using System.Linq;

namespace P01DAW__2023PA651_2022IV650__Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspaciosParqueoController : ControllerBase
    {
        private readonly ReservasContext _context;

        public EspaciosParqueoController(ReservasContext context)
        {
            _context = context;
        }

        // GET: api/espaciosparqueo
        [HttpGet]
        public ActionResult<IEnumerable<EspaciosParqueo>> GetEspaciosParqueo()
        {
            return _context.EspaciosParqueo.ToList();
        }

        // GET: api/espaciosparqueo/5
        [HttpGet("{id}")]
        public ActionResult<EspaciosParqueo> GetEspacioParqueo(int id)
        {
            var espacio = _context.EspaciosParqueo.Find(id);

            if (espacio == null)
            {
                return NotFound();
            }

            return espacio;
        }

        // POST: api/espaciosparqueo
        [HttpPost]
        public ActionResult<EspaciosParqueo> CreateEspacioParqueo(EspaciosParqueo nuevoEspacio)
        {
            _context.EspaciosParqueo.Add(nuevoEspacio);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetEspacioParqueo), new { id = nuevoEspacio.Id }, nuevoEspacio);
        }

        // PUT: api/espaciosparqueo/5
        [HttpPut("{id}")]
        public IActionResult UpdateEspacioParqueo(int id, EspaciosParqueo espacioActualizado)
        {
            if (id != espacioActualizado.Id)
            {
                return BadRequest();
            }

            _context.Entry(espacioActualizado).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEspacioParqueo(int id)
        {
            var espacio = _context.EspaciosParqueo.FirstOrDefault(e => e.Id == id);

            if (espacio == null)
            {
                return NotFound(new { mensaje = "Espacio de parqueo no encontrado." });
            }

            _context.EspaciosParqueo.Remove(espacio);
            _context.SaveChanges();

            return Ok(new { mensaje = "Espacio de parqueo eliminado correctamente." });
        }

    }
}
