using Microsoft.AspNetCore.Mvc;
using P01DAW__2023PA651_2022IV650__Reservas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;

namespace P01DAW__2023PA651_2022IV650__Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ReservasContext _ReservasContexto;

        public UsuariosController(ReservasContext ReservasContexto)
        {
            _ReservasContexto = ReservasContexto;
        }

        ///<sumary>
        ///Endpoint que retorna el listado de todos los Usuarios existentes
        ///</sumary>
        ///<returns></returns>
        [HttpGet]
        [Route("GetAll")]

        public IActionResult Get()
        {

            List<Usuarios> listadoUsuarios = (from e in _ReservasContexto.Usuarios
                                              select e).ToList();

            if (listadoUsuarios.Count() == 0)
            {
                return NotFound();
            }
            return Ok(listadoUsuarios);
        }
        [HttpGet]
        [Route("PorCredenciales/{nombre}")]
        public IActionResult Get(string nombre, string contrasena)
        {
            var listadoUsuarios = (from e in _ReservasContexto.Usuarios                              
                                where e.Nombre == nombre && e.Contrasena == contrasena
                                select new
                                {
                                    e.Id,
                                    e.Nombre,
                                    e.Rol,
                                    Credenciales="Usuario válido"

                                }).ToList();

            if (listadoUsuarios == null)
            {
                return NotFound();
            }
            return Ok(listadoUsuarios);
            
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult GuardarUsuario([FromBody] Usuarios usuario)
        {
            try
            {
                _ReservasContexto.Usuarios.Add(usuario);
                _ReservasContexto.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



        [HttpPut]
        [Route("actualizar/{id}")]

        public IActionResult ActualizarUsuario(int id, [FromBody] Usuarios usuarioModificar)
        {
         
            Usuarios? usuarioActual = (from e in _ReservasContexto.Usuarios
                                       where e.Id == id
                                       select e).FirstOrDefault();

            if (usuarioActual == null)
            {
                return NotFound();
            }

            // Verificar si el correo que se intenta actualizar ya existe en otro usuario
            var usuarioExistente = _ReservasContexto.Usuarios
                .FirstOrDefault(u => u.Nombre == usuarioModificar.Nombre && u.Id != id); 
            if (usuarioExistente != null)
            {
                return BadRequest("El Nombre ya está en uso por otro usuario.");
            }

            // Actualizar la información del usuario
            usuarioActual.Nombre = usuarioModificar.Nombre;
            usuarioActual.Correo = usuarioModificar.Correo;
            usuarioActual.Telefono = usuarioModificar.Telefono;
            usuarioActual.Contrasena = usuarioModificar.Contrasena;
            usuarioActual.Rol = usuarioModificar.Rol;

            // Marcar como modificado y guardar los cambios
            _ReservasContexto.Entry(usuarioActual).State = EntityState.Modified;
            _ReservasContexto.SaveChanges();

            return Ok(usuarioModificar);
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IActionResult EliminarCliente(int id)
        {
            //Se obtiene el original de la base
            Usuarios? usuario = (from e in _ReservasContexto.Usuarios
                                 where e.Id == id
                                 select e).FirstOrDefault();
            //Verificar si existe
            if (usuario == null)
                return NotFound();

            //Se elimina el registro
            _ReservasContexto.Usuarios.Attach(usuario);
            _ReservasContexto.Usuarios.Remove(usuario);
            _ReservasContexto.SaveChanges();
            return Ok(usuario);
        }

    }


}
