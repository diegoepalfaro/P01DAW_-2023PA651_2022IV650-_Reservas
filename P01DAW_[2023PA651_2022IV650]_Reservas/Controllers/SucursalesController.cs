using Microsoft.AspNetCore.Mvc;
using P01DAW__2023PA651_2022IV650__Reservas.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace P01DAW__2023PA651_2022IV650__Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly ReservasContext _context;

        public SucursalesController(ReservasContext context)
        {
            _context = context;
        }

        // Obtener todas las sucursales
        [HttpGet]
        public ActionResult<IEnumerable<Sucursales>> GetSucursales()
        {
            var sucursales = _context.Sucursales.ToList();
            return Ok(sucursales);
        }

        // Obtener una sucursal por ID
        [HttpGet("{id}")]
        public ActionResult<Sucursales> GetSucursal(int id)
        {
            var sucursal = _context.Sucursales.Find(id);

            if (sucursal == null)
            {
                return NotFound();
            }

            return Ok(sucursal);
        }

        // Crear una nueva sucursal
        [HttpPost]
        public ActionResult<Sucursales> CreateSucursal([FromBody] Sucursales sucursal)
        {
            if (sucursal == null)
            {
                return BadRequest("Los datos de la sucursal son inválidos.");
            }

            _context.Sucursales.Add(sucursal);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetSucursal), new { id = sucursal.Id }, sucursal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSucursal(int id, [FromBody] Sucursales sucursal)
        {
            if (sucursal == null || id != sucursal.Id)
            {
                return BadRequest("Los datos enviados no son válidos.");
            }

            var sucursalExistente = _context.Sucursales.FirstOrDefault(s => s.Id == id);
            if (sucursalExistente == null)
            {
                return NotFound($"No se encontró una sucursal con el ID {id}.");
            }

            // Actualizamos los datos
            sucursalExistente.Nombre = sucursal.Nombre;
            sucursalExistente.Direccion = sucursal.Direccion;
            sucursalExistente.Telefono = sucursal.Telefono;
            sucursalExistente.Administrador = sucursal.Administrador;
            sucursalExistente.NumeroEspacios = sucursal.NumeroEspacios;

            _context.SaveChanges();

            return Ok(sucursalExistente); // Retorna la sucursal actualizada
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSucursal(int id)
        {
            var sucursal = _context.Sucursales.FirstOrDefault(s => s.Id == id);
            if (sucursal == null)
            {
                return NotFound($"No se encontró una sucursal con el ID {id}.");
            }

            _context.Sucursales.Remove(sucursal);
            _context.SaveChanges();

            return Ok($"La sucursal con ID {id} fue eliminada correctamente.");
        }

    }
}
