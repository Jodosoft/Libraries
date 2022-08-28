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

using System;
using System.Collections.Generic;
using Jodo.Primitives;

namespace Jodo.Numerics
{
    public class NumericVariant
    {
        public static TNumeric Generate<TNumeric>(Random random, Scenarios scenarios) where TNumeric : struct, INumeric<TNumeric>
        {
            List<Func<TNumeric>> factories = new List<Func<TNumeric>>();

            if (scenarios.HasFlag(Scenarios.Defaults))
                factories.Add(() => default);

            if (scenarios.HasFlag(Scenarios.LowMagnitude))
                factories.Add(() => GenerateLowMagnitude<TNumeric>(random));

            if (scenarios.HasFlag(Scenarios.AnyMagnitude))
                factories.Add(() => random.NextNumeric<TNumeric>(Generation.Extended));

            if (scenarios.HasFlag(Scenarios.Extremes))
            {
                factories.Add(() => Numeric.MaxValue<TNumeric>());
                factories.Add(() => Numeric.MinValue<TNumeric>());
            }

            if (scenarios.HasFlag(Scenarios.Errors))
            {
                if (Numeric.HasNaN<TNumeric>()) factories.Add(() => ConvertN.ToNumeric<TNumeric>(double.NaN, Conversion.Cast));

                if (Numeric.HasInfinity<TNumeric>())
                {
                    factories.Add(() => ConvertN.ToNumeric<TNumeric>(double.PositiveInfinity, Conversion.Cast));
                    if (Numeric.IsSigned<TNumeric>())
                        factories.Add(() => ConvertN.ToNumeric<TNumeric>(double.NegativeInfinity, Conversion.Cast));
                }
            }

            if (factories.Count > 0)
                return random.NextElement(factories)();

            return random.NextNumeric<TNumeric>(Generation.Extended);
        }

        private static TNumeric GenerateLowMagnitude<TNumeric>(Random random) where TNumeric : struct, INumeric<TNumeric>
        {
            TNumeric ten = ConvertN.ToNumeric<TNumeric>(10);
            TNumeric bound = MathN.Min(
                Numeric.MaxValue<TNumeric>().Divide(ten),
                ConvertN.ToNumeric<TNumeric>(100));

            TNumeric minValue = Numeric.IsSigned<TNumeric>() ? bound.Negative() : Numeric.Zero<TNumeric>();
            TNumeric maxValue = Numeric.IsSigned<TNumeric>() ? bound.Negative() : bound.Doubled();

            TNumeric result = random.NextNumeric(minValue, maxValue, Generation.Extended);

            if (Numeric.IsReal<TNumeric>())
                result = MathN.Round(result.Divide(ten), 1);

            return result;
        }
    }
}
