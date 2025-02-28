using Microsoft.AspNetCore.Mvc;
using P01DAW__2023PA651_2022IV650__Reservas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using P01DAW__2023PA651_2022IV650__Reservas.Models;

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

        [HttpPost]
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
        {
            if (Id != reserva.Id)
            {
            }

                {
            }


            reservaExistente.UsuarioId = reserva.UsuarioId;
            reservaExistente.EspacioParqueoId = reserva.EspacioParqueoId;
            reservaExistente.Fecha = reserva.Fecha;
            reservaExistente.HoraInicio = reserva.HoraInicio;
            reservaExistente.CantidadHoras = reserva.CantidadHoras;

            _context.SaveChanges();
            return NoContent();
        }

        {
            if (reserva == null)
            {
            }

            _context.Reservas.Remove(reserva);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
