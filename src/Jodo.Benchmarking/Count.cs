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
using System.Diagnostics.CodeAnalysis;

namespace Jodo.Benchmarking
{
    [ExcludeFromCodeCoverage]
    public sealed class Count : IEquatable<Count>
    {
        public long Executions { get; }
        public TimeSpan TotalTime { get; }

        public Count(long executions, TimeSpan totalTime)
        {
            if (executions <= 0) throw new ArgumentOutOfRangeException(nameof(executions), executions, "Must be positive.");
            if (totalTime <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(totalTime), totalTime, "Must be positive.");

            Executions = executions;
            TotalTime = totalTime;
        }

        public TimeSpan GetAverageTime() => new TimeSpan(TotalTime.Ticks / Executions);

        public double GetExecutionsPerSecond() => Executions / TotalTime.TotalSeconds;

        public override bool Equals(object obj) => Equals(obj as Count);

        public bool Equals(Count other) => other != null && Executions == other.Executions && TotalTime.Equals(other.TotalTime);

        public override int GetHashCode() => HashCode.Combine(Executions, TotalTime);

        public static bool operator ==(Count left, Count right) => left.Equals(right);

        public static bool operator !=(Count left, Count right) => !(left == right);

        public static Count operator +(Count count1, Count count2)
            => new Count(count1.Executions + count2.Executions, count1.TotalTime + count2.TotalTime);
    }
}
