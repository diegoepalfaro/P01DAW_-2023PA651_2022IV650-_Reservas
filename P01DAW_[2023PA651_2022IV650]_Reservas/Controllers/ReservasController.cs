using Microsoft.AspNetCore.Mvc;
using P01DAW__2023PA651_2022IV650__Reservas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace P01DAW__2023PA651_2022IV650__Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly ReservasContext _context;

        public ReservasController(ReservasContext context)
        {
            _context = context;
        }

        // Obtener todas las reservas
        [HttpGet]
        public ActionResult<IEnumerable<Reservas>> GetReservas()
        {
            return _context.Reservas.ToList();
        }

        // Obtener una reserva por ID
        [HttpGet("{Id}")]
        public ActionResult<Reservas> GetReserva(int Id)
        {
            var reserva = _context.Reservas.Find(Id);
            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }

        // Crear una nueva reserva
        [HttpPost]
        public ActionResult<Reservas> CreateReserva(Reservas reserva)
        {
            _context.Reservas.Add(reserva);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetReserva), new { Id = reserva.Id }, reserva);
        }

        // Actualizar una reserva existente
        [HttpPut("{Id}")]
        public IActionResult UpdateReserva(int Id, Reservas reserva)
        {
            if (Id != reserva.Id)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Reservas.Any(e => e.Id == Id))
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

        // Eliminar una reserva
        [HttpDelete("{Id}")]
        public IActionResult DeleteReserva(int Id)
        {
            var reserva = _context.Reservas.FirstOrDefault(r => r.Id == Id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
