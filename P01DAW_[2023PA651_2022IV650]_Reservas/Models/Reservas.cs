using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P01DAW__2023PA651_2022IV650__Reservas.Models
{
    public class Reservas
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        
        public int EspacioParqueoId { get; set; }
        
        public DateTime Fecha{ get; set; }

        public TimeSpan HoraInicio { get; set; }
        public int CantidadHoras { get; set; }

    }
}
