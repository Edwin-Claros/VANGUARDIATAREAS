using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class Prioridad
    {
        public int prioridadId { get; set; }
        public string prioridadNombre { get; set; }

        public List<ItinerarioDetalle> ItinerarioDetalles { get; set; }

    }
}
