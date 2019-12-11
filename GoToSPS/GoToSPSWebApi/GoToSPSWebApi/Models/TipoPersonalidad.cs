using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class TipoPersonalidad
    {
        public int tipoPersonalidadId { get; set; }
        public string tipoPersonalidadNombre { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}
