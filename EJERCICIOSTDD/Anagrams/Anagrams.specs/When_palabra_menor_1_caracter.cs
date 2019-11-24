using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anagrams.specs
{
    class When_palabra_menor_1_caracter
    {
        private static Anagrama _anagrama;
        private static bool EvaluarLetra;

        Establish context = () =>
        {
            _anagrama = new Anagrama("s", "s");
            EvaluarLetra = _anagrama.esMayorQue1();

        };

        It Should_no_be_greater_1_character = () => EvaluarLetra.ShouldBeTrue();  
    }
}
