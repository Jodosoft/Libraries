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

using Jodo.Extensions.Benchmarking.Internals;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Jodo.Extensions.Benchmarking
{
    public static class Measurer
    {
        [MethodImpl(MethodImplOptions.NoOptimization)]
        public static Measurement Measure(Func<object> function, TimeSpan duration)
        {
            var checkObj = new object();
            var stopwatch = new Stopwatch();
            var maxTicks = duration.TotalSeconds * Stopwatch.Frequency;
            ulong iterations = 0;
            object obj;
            stopwatch.Start();
            do
            {
                obj = function();
                iterations++;
            } while (stopwatch.ElapsedTicks < maxTicks);
            stopwatch.Stop();
            if (ReferenceEquals(obj, checkObj)) throw new InvalidOperationException();
            return new Measurement(iterations, stopwatch.Elapsed);
        }
    }
}
