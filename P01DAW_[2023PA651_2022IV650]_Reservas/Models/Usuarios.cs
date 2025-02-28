using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace P01DAW__2023PA651_2022IV650__Reservas.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string ContrasenaHash { get; set; }
        public string Rol { get; set; }
    }
}
