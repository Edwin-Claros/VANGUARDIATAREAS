using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoToSPSWebApi.Models
{
    public class Categoria
    {
        public int categoriaId { get; set; }
        public string categoriaNombre { get; set; }

        public List<Actividad> Actividades { get; set; }
    }
}
