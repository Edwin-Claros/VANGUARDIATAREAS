using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class TipoAmbiente
    {
        public int tipoAmbienteId { get; set; }
        public string tipoAmbienteNombre { get; set; }

        public List<Usuario> Usuarios { get; set; }
        public List<Lugar> Lugares { get; set; }
    }
}
