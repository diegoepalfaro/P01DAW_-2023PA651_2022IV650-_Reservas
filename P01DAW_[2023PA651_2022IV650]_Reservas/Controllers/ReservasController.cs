using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using P01DAW__2023PA651_2022IV650__Reservas.Models;

namespace P01DAW_2023PA651_2022IV650_Reservas.Controllers
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


        [HttpGet]
        public ActionResult<IEnumerable<Reservas>> GetReservas()
        {
            return _context.Reservas.ToList();
        }


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


        [HttpGet("usuario/{usuarioId}")]
        public ActionResult<IEnumerable<Reservas>> GetReservasPorUsuario(int usuarioId)
        {
            var reservas = _context.Reservas
                                   .Where(r => r.UsuarioId == usuarioId)
                                   .ToList();

            if (reservas.Count == 0)
            {
                return NotFound("No hay reservas activas para este usuario.");
            }

            return Ok(reservas);
        }


        [HttpPost]
        public ActionResult<Reservas> CreateReserva([FromBody] Reservas reserva)
        {
            if (reserva == null)
            {
                return BadRequest("La reserva no puede ser nula.");
            }


            _context.Reservas.Add(reserva);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetReserva), new { Id = reserva.Id }, reserva);
        }


        [HttpPut("{Id}")]
        public IActionResult UpdateReserva(int Id, [FromBody] Reservas reserva)
        {
            if (Id != reserva.Id)
            {
                return BadRequest("El ID de la reserva no coincide.");
            }

            var reservaExistente = _context.Reservas.Find(Id);
            if (reservaExistente == null)
            {
                return NotFound("Reserva no encontrada.");
            }


            reservaExistente.UsuarioId = reserva.UsuarioId;
            reservaExistente.EspacioParqueoId = reserva.EspacioParqueoId;
            reservaExistente.Fecha = reserva.Fecha;
            reservaExistente.HoraInicio = reserva.HoraInicio;
            reservaExistente.CantidadHoras = reserva.CantidadHoras;

            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult CancelarReserva(int id)
        {
            var reserva = _context.Reservas.Find(id);
            if (reserva == null)
            {
                return NotFound("Reserva no encontrada.");
            }

            _context.Reservas.Remove(reserva);
            _context.SaveChanges();

            return NoContent();
        }
    }
}