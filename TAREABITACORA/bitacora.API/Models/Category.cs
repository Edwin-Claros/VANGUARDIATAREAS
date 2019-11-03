using System.Collections.Generic;

namespace bitacora.API.Models
{
   public class Category{
        public int categoryId{get;set;}
        public string categoryNombre{get;set;}
        public string categoryDescripcion{get;set;}
          public List<Bitacora> Bitacoras { get; set; }
    }
}