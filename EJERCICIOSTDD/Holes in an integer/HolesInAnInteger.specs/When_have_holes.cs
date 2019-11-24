using Holes_in_an_integer;
using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolesInAnInteger.specs
{
    class When_have_holes
    {
        private static HolesInAnIntegers _holesInAnInteger;
        private static int EvaluarAgujeros;

        Establish context = () =>
        {
            _holesInAnInteger = new HolesInAnIntegers(889);
            EvaluarAgujeros = _holesInAnInteger.cuantosAgujeros();

        };

        It Should_have_holes = () => EvaluarAgujeros.ShouldEqual(4);
    }
}

