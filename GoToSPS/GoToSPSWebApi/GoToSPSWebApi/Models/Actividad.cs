using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class Actividad
    {
        public int actividadId { get; set; }
        public string actividadNombre { get; set; }
        public string actividadDescripcion { get; set; }
        public string actividadHorario { get; set; }
        public DateTime actividadDuracion { get; set; }

        public int lugar_Id { get; set; }
        public int categoria_Id { get; set; }
        public int jornada_Id { get; set; }

        public Categoria Categoria { get; set; }
        public Jornada Jornada { get; set; }
        public Lugar Lugar { get; set; }
        public List<ItinerarioDetalle> ItinerarioDetalles { get; set; }
    }
}
