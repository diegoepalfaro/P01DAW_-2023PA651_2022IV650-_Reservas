using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P01DAW__2023PA651_2022IV650__Reservas.Models
{
    public class Sucursales
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public int AdministradorId { get; set; }

        public Usuarios Administrador { get; set; }

        public int TotalEspacios { get; set; }

}
