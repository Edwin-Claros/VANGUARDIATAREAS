using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class Ciudad
    {
        public int ciudadId { get; set; }
        public string ciudadNombre { get; set; }

        public List<ItinerarioEncabezado> ItinerarioEncabezados { get; set; }
        public List<Lugar> Lugares { get; set; }
    }
}
