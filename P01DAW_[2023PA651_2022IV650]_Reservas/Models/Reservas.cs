using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace P01DAW__2023PA651_2022IV650__Reservas.Models
{
    public class Reservas
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int EspacioParqueoId { get; set; }
        public EspacioParqueo EspacioParqueo { get; set; }
        public DateTime FechaReserva { get; set; }

        public TimeSpan HoraInicio { get; set; }
        public int Horas { get; set; }

    }
}
