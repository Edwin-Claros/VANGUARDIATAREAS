using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Anagrams.specs
{
    class When_not_null
    {
        private static Anagrama _anagrama;

        Establish context = () =>
        {
            _anagrama = new Anagrama();
        };

        It should_not_be_null = () => _anagrama.ShouldNotBeNull();
    }
}
