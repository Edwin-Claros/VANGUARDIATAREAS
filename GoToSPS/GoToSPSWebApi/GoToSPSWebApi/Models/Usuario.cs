using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class Usuario
    {
        public int usuarioId { get; set; }
        public string usuarioNombre { get; set; }
        public string usuarioClave { get; set; }
        public char usuarioSexo { get; set; }

        public int tipoUsuario_Id { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public List<Actividad> Actividades { get; set; }
    }
}
