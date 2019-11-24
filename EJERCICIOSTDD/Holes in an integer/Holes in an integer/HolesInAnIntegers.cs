using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Holes_in_an_integer
{
    public class HolesInAnIntegers
    {
        public int Numero { get; set; }

        public HolesInAnIntegers(int _numero)
        {
            Numero = _numero;
        }

        int[] ArrayAgujeros = { 1, 0, 0, 0, 1, 0, 1, 0, 2, 1 };

        public int cuantosAgujeros()
        {
            int agujeros = 0;

            while (Numero > 0)
            {
                int d = Numero % 10;
                agujeros += ArrayAgujeros[d];
                Numero /= 10;
            } 
            return agujeros;
        }
    }
}
