using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anagrams.specs
{
    class When_is_anagrama
    {
        private static Anagrama _anagrama;
        private static string EvaluarAnagrama;

        Establish context = () =>
        {
            _anagrama = new Anagrama("s", "s");
            EvaluarAnagrama = _anagrama.esAnagrama();

        };

        It Should_no_be_ = () => EvaluarAnagrama.ShouldEqual("Es Anagrama");
    }
}
