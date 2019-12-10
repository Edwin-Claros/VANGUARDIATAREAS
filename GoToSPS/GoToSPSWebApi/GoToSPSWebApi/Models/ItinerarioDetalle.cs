using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class ItinerarioDetalle
    {
        public int itinerarioDetalleId { get; set; }

        public int actividad_Id { get; set; }
        public int prioridad_Id { get; set; }
        public int itinerarioEncabezado_Id { get; set; }

        public Prioridad Prioridad { get; set; }
        public Actividad Actividad { get; set; }
        public ItinerarioEncabezado ItinerarioEncabezado { get; set; }
    }
}
