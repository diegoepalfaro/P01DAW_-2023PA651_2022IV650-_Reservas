using Microsoft.AspNetCore.Mvc;
using P01DAW__2023PA651_2022IV650__Reservas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace P01DAW__2023PA651_2022IV650__Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly ReservasContext _ReservasContexto;

        public SucursalesController(ReservasContext ReservasContexto)
        {
            _ReservasContexto = ReservasContexto;
        }

        ///<sumary>
        ///Endpoint que retorna el listado de todos Sucursales existentes
        ///</sumary>
        ///<returns></returns>
        [HttpGet]
        [Route("GetAllSucursales")]

        public IActionResult Get()
        {

            List<Sucursales> listadoSucursales = (from e in _ReservasContexto.Sucursales
                                                  select e).ToList();

            if (listadoSucursales.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoSucursales);
        }


        [HttpPost]
        [Route("AddSucursal")]
        public IActionResult GuardarSucursal([FromBody] Sucursales sucursal)
        {
            try
            {

                _ReservasContexto.Sucursales.Add(sucursal);
                _ReservasContexto.SaveChanges();


                if (sucursal.NumeroEspacios > 0)
                {
                    for (int i = 0; i < sucursal.NumeroEspacios; i++)
                    {
                        var espacio = new EspaciosParqueo
                        {
                            SucursalId = sucursal.Id,
                            NumeroEspacio = (i + 1).ToString(),
                            Ubicacion = $"Espacio {i + 1}",
                            CostoPorHora = 5.00m,
                            Estado = "Disponible"
                        };


                        _ReservasContexto.EspaciosParqueo.Add(espacio);
                    }


                    _ReservasContexto.SaveChanges();
                }

                return Ok(sucursal);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddEspacio")]
        public IActionResult GuardarEspacio(int sucursalId, [FromBody] EspaciosParqueo espacio)
        {
            var listadoSucursales = (from e in _ReservasContexto.Sucursales
                                   where e.Id == sucursalId
                                   select new
                                   {
                                       e.Id,
                                       e.Nombre

                                   }).ToList();
            if (listadoSucursales.Count>0)
            {
                try
                {
                    
                    sucursalId = espacio.SucursalId;
                    _ReservasContexto.SaveChanges();
                    return Ok(espacio);
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("La sucursal elegida no existe");
            }
            

        }


        [HttpPut]
        [Route("actualizarSucursal/{id}")]

        public IActionResult ActualizarSucursal(int id, [FromBody] Sucursales SucursalModificar)
        {

            Sucursales? sucursalActual = (from e in _ReservasContexto.Sucursales
                                          where e.Id == id
                                          select e).FirstOrDefault();

            if (sucursalActual == null)
            {
                return NotFound();
            }


            var sucursalExistente = _ReservasContexto.Sucursales
                .FirstOrDefault(u => u.Nombre == SucursalModificar.Nombre && u.Id != id);
            if (sucursalExistente != null)
            {
                return BadRequest("El Nombre ya está en uso por otro usuario.");
            }

            // Actualizar la información del usuario
            sucursalActual.Nombre = SucursalModificar.Nombre;
            sucursalActual.Administrador = SucursalModificar.Administrador;
            sucursalActual.Telefono = SucursalModificar.Telefono;
            sucursalActual.Direccion = SucursalModificar.Direccion;


            // Marcar como modificado y guardar los cambios
            _ReservasContexto.Entry(sucursalActual).State = EntityState.Modified;
            _ReservasContexto.SaveChanges();

            return Ok(SucursalModificar);
        }

        [HttpPut]
        [Route("actualizarEspacio/{id}")]

        public IActionResult ActualizarEspacio(int id, [FromBody] EspaciosParqueo espacioModificar)
        {

            EspaciosParqueo? espacioActual = (from e in _ReservasContexto.EspaciosParqueo
                                          where e.Id == id
                                          select e).FirstOrDefault();

            if (espacioActual == null)
            {
                return NotFound();
            }

            // Actualizar la información del usuario
            espacioActual.Estado = espacioModificar.Estado;
            espacioActual.SucursalId = espacioModificar.SucursalId;
            espacioActual.Ubicacion = espacioModificar.Ubicacion;
            espacioActual.CostoPorHora = espacioModificar.CostoPorHora;
            espacioActual.Ubicacion = espacioModificar.Ubicacion;

            // Marcar como modificado y guardar los cambios
            _ReservasContexto.Entry(espacioActual).State = EntityState.Modified;
            _ReservasContexto.SaveChanges();

            return Ok(espacioModificar);
        }

        [HttpDelete]
        [Route("eliminarSucursal/{id}")]
        public IActionResult EliminarSucursal(int id)
        {
            //Se obtiene el original de la base
            Sucursales? sucursal = (from e in _ReservasContexto.Sucursales
                                    where e.Id == id
                                    select e).FirstOrDefault();
            //Verificar si existe
            if (sucursal == null)
                return NotFound();

            //Se elimina el registro
            _ReservasContexto.Sucursales.Attach(sucursal);
            _ReservasContexto.Sucursales.Remove(sucursal);
            _ReservasContexto.SaveChanges();
            return Ok(sucursal);
        }

        [HttpDelete]
        [Route("eliminarEspacio/{id}")]
        public IActionResult EliminarEspacio(int id)
        {
            //Se obtiene el original de la base
            EspaciosParqueo? espacio = (from e in _ReservasContexto.EspaciosParqueo
                                    where e.Id == id
                                    select e).FirstOrDefault();
            //Verificar si existe
            if (espacio == null)
                return NotFound();

            //Se elimina el registro
            _ReservasContexto.EspaciosParqueo.Attach(espacio);
            _ReservasContexto.EspaciosParqueo.Remove(espacio);
            _ReservasContexto.SaveChanges();
            return Ok(espacio);
        }

    }
    
     




}
