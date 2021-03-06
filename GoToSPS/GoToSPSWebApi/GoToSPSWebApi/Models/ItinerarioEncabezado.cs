﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class ItinerarioEncabezado
    {
        public int itinerarioEncabezadoId { get; set; }
        public string itinerarioEncabezadoNombre { get; set; }
        public DateTime itinerarioEncabezadoFechaInicio { get; set; }
        public DateTime itinerarioEncabezadoFechaFinal { get; set; }

        public int lugar_Id { get; set; }
        public int ciudad_Id { get; set; }
        public int usuario_Id { get; set; }

        public Lugar Lugar { get; set; }
        public Ciudad Ciudad { get; set; }
        public Usuario Usuario { get; set; }

        public List<ItinerarioDetalle> ItinerarioDetalles { get; set; }
    }
}
