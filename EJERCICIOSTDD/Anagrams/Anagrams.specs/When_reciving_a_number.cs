using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anagrams.specs
{
    class When_reciving_a_number
    {
        private static Anagrama _anagrama;
        private static bool EvaluarLetra;

        Establish context = () =>
        {
            _anagrama = new Anagrama("s", "hol");
            EvaluarLetra = _anagrama.noEsNumero();

        };

        It Should_no_be_number = () => EvaluarLetra.ShouldBeTrue();
    }
}
