using FluentAssertions;
using Jodo.Extensions.Primitives;
using Jodo.Extensions.Testing;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;

namespace Jodo.Extensions.Numerics.Tests
{
    public sealed class Showcase : GlobalTestBase
    {
        public StringBuilder ConsoleOuput;

        [SetUp]
        public void SetUp()
        {
            ConsoleOuput = new StringBuilder();
            Console.SetOut(new StringWriter(ConsoleOuput));
        }

        [TearDown]
        public void TearDown()
        {
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }

        [Test]
        public void FixedPointArithmetic_LargeValues_NoLossOfPrecision()
        {
            var floatingPoint = 1000000 + MathF.PI;
            var fixedPoint = 1000000 + Math<fix64>.PI;

            Console.WriteLine(floatingPoint); // outputs: 1000003.1
            Console.WriteLine(fixedPoint); // outputs: 1000003.141592

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("1000003.1", "1000003.141592");
        }

        [Test]
        public void Github_CodeSample()
        {
            var f1 = 2 * Math<fix64>.PI;
            var f2 = f1 / 1000;

            var i1 = (xint)1234;
            var i2 = i1 >> 0b11;

            Console.WriteLine(f1); // outputs: 6.283184
            Console.WriteLine(f2); // outputs: 0.006283
            Console.WriteLine(i1); // outputs: 1234
            Console.WriteLine($"{i2:X}"); // outputs: 9A

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("6.283184", "0.006283", "1234", "9A");
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

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("255", "200", "0");
        }
    }
}
