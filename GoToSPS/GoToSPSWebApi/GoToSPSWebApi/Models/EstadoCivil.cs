using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class EstadoCivil
    {
        public int estadoCivilId { get; set; }
        public string estadoCivilNombre { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}
