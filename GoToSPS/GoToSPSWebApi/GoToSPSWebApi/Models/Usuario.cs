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
        public DateTime usuarioFechaNacimiento { get; set; }
        public string usuarioMedioTransporte { get; set; }
        public string usuarioProfesion { get; set; }
        public string usuarioInteres { get; set; }

        public int tipoUsuario_Id { get; set; }
        public int tipoPersonalidad_Id { get; set; }
        public int estadoCivil_Id { get; set; }
        public int tipoAmbiente_Id { get; set; }

        public TipoUsuario TipoUsuario { get; set; }
        public TipoPersonalidad TipoPersonalidad { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public TipoAmbiente TipoAmbiente { get; set; }

        public List<ItinerarioEncabezado> ItinerarioEncabezados { get; set; }
    }
}
