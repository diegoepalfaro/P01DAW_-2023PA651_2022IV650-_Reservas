using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P01DAW__2023PA651_2022IV650__Reservas.Models
{
    public class EspaciosParqueo
    {
        [Key]
        public int Id { get; set; }
        public int SucursalId { get; set; }

        public Sucursales Sucursal { get; set; }

        public string NumeroEspacio { get; set; }

        public string Ubicacion { get; set; }

        public decimal CostoPorHora { get; set; }

        public string Estado { get; set; } // Disponible / Ocupado

    }
}
