using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class TipoUsuario
    {
        public int tipoUsuarioId { get; set; }
        public string tipoUsuarioNombre { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}
