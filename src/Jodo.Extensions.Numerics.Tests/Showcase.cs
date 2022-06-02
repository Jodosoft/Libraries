using FluentAssertions;
using Jodo.Extensions.Primitives;
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;

namespace Jodo.Extensions.Numerics.Tests
{
    public sealed class Showcase : GlobalTestBase
    {
        [Test]
        public void FixedPointArithmetic_LargeValues_NoLossOfPrecision()
        {
            var fixedPoint = 1_000_000_000_000 + Math<fix64>.PI;
            var floatingPoint = 1_000_000_000_000 + MathF.PI;

            //  fixedPoint -= 1_000_000_000_000;
            //  floatingPoint -= 1_000_000_000_000;

            Console.WriteLine(fixedPoint); // outputs: 3.141592
            Console.WriteLine($"{floatingPoint:0.000000}"); // outputs: 1000000000000.000000
        }

        [Test]
        public void Github_CodeSample()
        {
            var fixedPoint = 1_000_000_000_000 + Math<fix64>.PI;
            var remainder = fixedPoint % 1_000_000_000_000;

            var vector = new Vector2<xint>(1234, -2);
            var bitShift = vector.X >> 0b11;

            Console.WriteLine($"{fixedPoint:E3}"); // outputs: 1.000E+012
            Console.WriteLine(remainder); // outputs: 3.141592
            Console.WriteLine(vector); // outputs: (1234, -2)
            Console.WriteLine($"{bitShift:X}"); // outputs: 9A
        }

        [Test]
        public void CastConvertAndClamp()
        {
            var castResult = Cast<xbyte>.ToValue(1023);
            var convertResult = Convert<xbyte>.ToValue(199.956M);
            var clampResult = Clamp<xbyte>.ToValue(-100);

            Console.WriteLine(castResult); // outputs: 255
            Console.WriteLine(convertResult); // outputs: 200
            Console.WriteLine(clampResult); // outputs: 0
        }
    }
}
