using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class Jornada
    {
        public int jornadaId { get; set; }
        public string jornadaNombre { get; set; }

        public List<Actividad> Actividades { get; set; }
    }
}
