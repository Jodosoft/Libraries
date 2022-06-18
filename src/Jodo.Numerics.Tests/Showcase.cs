// Copyright (c) 2022 Joseph J. Short
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.

#if NETSTANDARD2_1_OR_GREATER

using System;
using System.IO;
using System.Text;
using FluentAssertions;
using Jodo.Primitives;
using NUnit.Framework;

namespace Jodo.Numerics.Tests
{
    public sealed class Showcase : Testing.GlobalFixtureBase
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
            float floatingPoint = 1000000 + MathF.PI;
            fix64 fixedPoint = 1000000 + Math<fix64>.PI;

            Console.WriteLine(floatingPoint); // outputs: 1000003.1
            Console.WriteLine(fixedPoint); // outputs: 1000003.141592

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("1000003.1", "1000003.141592");
        }

        [Test]
        public void CodeSample_Summary()
        {
            xint w = -100 + Math<xint>.Max(1234, 4321);
            Vector2<xint> v = new Vector2<xint>(w, w >> 0b11);

            fix64 f = 2 * Math<fix64>.PI;
            ReadOnlySpan<byte> b = BitConverter<fix64>.GetBytes(f);

            Console.WriteLine(w); // outputs: 4221
            Console.WriteLine($"{v:X}"); // outputs: →(107D, 20F)

            Console.WriteLine(f); // outputs: 6.283184
            Console.WriteLine(b.ToString()); // outputs: System.ReadOnlySpan<Byte>[8]

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("4221", "→(107D, 20F)", "6.283184", "System.ReadOnlySpan<Byte>[8]");
        }

        [Test]
        public void CodeSample_StringFormatting()
        {
            xint var1 = (xint)1024;
            fix64 var2 = (fix64)99.54322f;

            Console.WriteLine($"{var1:N}"); // outputs: 1,024.00
            Console.WriteLine($"{var1:X}"); // outputs: 400
            Console.WriteLine($"{var2:E}"); // outputs: 9.954322E+001
            Console.WriteLine($"{var2:000.000}"); // outputs: 099.543

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("1,024.00", "400", "9.954322E+001", "099.543");
        }

        [Test]
        public void CodeSample_RandomGeneration()
        {
            xdouble var1 = Random.NextNumeric<xdouble>();
            xdouble var2 = Random.NextNumeric<xdouble>(100, 120);

            Console.WriteLine(var1); // outputs: -7.405808417991177E+115 (example)
            Console.WriteLine(var2); // outputs: 102.85086051826445 (example)

            ConsoleOuput.ToString().Should().Contain("1");
        }

        [Test]
        public void CastConvertAndClamp()
        {
            xbyte castResult = Cast<xbyte>.ToNumeric(1023);
            xbyte convertResult = Convert<xbyte>.ToNumeric(199.956M);
            xbyte clampResult = Clamp<xbyte>.ToNumeric(-100);

            Console.WriteLine(castResult); // outputs: 255
            Console.WriteLine(convertResult); // outputs: 200
            Console.WriteLine(clampResult); // outputs: 0

            ConsoleOuput.ToString().Split(Environment.NewLine)
                .Should().ContainInOrder("255", "200", "0");
        }
    }
}
#endif
