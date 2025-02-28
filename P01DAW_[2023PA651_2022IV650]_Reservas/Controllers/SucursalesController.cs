using Microsoft.AspNetCore.Mvc;
using P01DAW__2023PA651_2022IV650__Reservas.Models;
using Microsoft.EntityFrameworkCore;

namespace P01DAW__2023PA651_2022IV650__Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {

        {
        }

        [HttpGet]
        {
        }
            return Ok(listadoSucursales);
        }

        {

            {
            }


                    _ReservasContexto.SaveChanges();
                }

            return Ok(sucursal);
        }
            catch (Exception ex)
            {

        [HttpPost]
        {
            {
            }
                catch (Exception ex)
                {


        }

        {
            {
            }

            {
            }



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

        {
            if (sucursal == null)
            }


        }

    }
    
     




}
