﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class Lugar
    {
        public int lugarId { get; set; }
        public string lugarNombre { get; set; }
        public string lugarFoto { get; set; }
        public DateTime lugarHoraEntrada { get; set; }
        public DateTime lugarHoraCierre { get; set; }

        public int ciudad_Id { get; set; }
        public int tipoAmbiente_Id { get; set; }

        public Ciudad Ciudad { get; set; }
        public TipoAmbiente TipoAmbiente { get; set; }

        public List<ItinerarioEncabezado> ItinerarioEncabezado { get; set; }
        public List<Actividad> Actividades { get; set; }
    }
}
