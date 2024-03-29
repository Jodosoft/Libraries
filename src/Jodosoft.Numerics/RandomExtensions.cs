﻿// Copyright (c) 2023 Joe Lawry-Short
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
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

namespace Jodosoft.Numerics
{
    public static class RandomExtensions
    {
        private const string InvalidGenerationValue = $"The value '{{0}}' is not valid for this usage of the type {nameof(Generation)}.";
        private const string XCannotBeGreaterThanY = "'{0}' cannot be greater than '{1}'.";
        private const string XMustBeFinite = "'{0}' must be a finite value.";

        // These values are the cube roots of MaxValue for their respective types.
        private const sbyte LowMagnitudeSByte = 5;
        private const byte LowMagnitudeByte = 6;
        private const short LowMagnitudeInt16 = 32;
        private const ushort LowMagnitudeUInt16 = 40;
        private const int LowMagnitudeInt32 = 1290;
        private const uint LowMagnitudeUInt32 = 1625;
        private const long LowMagnitudeInt64 = 2097152;
        private const ulong LowMagnitudeUInt64 = 2642246;

        // Arbitrary low-magnitude numbers chosen to be well within each types' maximum digits of precision.
        private const int LowMagnitudeDecimalPlaces = 1;
        private const float LowMagnitudeSingle = 100.0f;
        private const double LowMagnitudeDouble = 10000.0d;
        private const decimal LowMagnitudeDecimal = 100.0m;

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric NextNumeric<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericRandom<TNumeric>>.Instance.Generate(random);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric NextNumeric<TNumeric>(this Random random, TNumeric maxValue) where TNumeric : struct, INumeric<TNumeric>
           => DefaultProvider<TNumeric, INumericRandom<TNumeric>>.Instance.Generate(random, maxValue);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric NextNumeric<TNumeric>(this Random random, TNumeric minValue, TNumeric maxValue) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericRandom<TNumeric>>.Instance.Generate(random, minValue, maxValue);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric NextNumeric<TNumeric>(this Random random, Generation mode) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericRandom<TNumeric>>.Instance.Generate(random, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric NextNumeric<TNumeric>(this Random random, TNumeric minValue, TNumeric maxValue, Generation mode) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, INumericRandom<TNumeric>>.Instance.Generate(random, minValue, maxValue, mode);

        [DebuggerStepThrough]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TNumeric NextNumeric<TNumeric>(this Random random, Variants variants) where TNumeric : struct, INumeric<TNumeric>
            => DefaultProvider<TNumeric, IVariantRandom<TNumeric>>.Instance.Generate(random, variants);

        public static UnitN<TNumeric> NextUnit<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
        {
            return new UnitN<TNumeric>(random.NextNumeric(Numeric.MinUnit<TNumeric>(), Numeric.MaxUnit<TNumeric>(), Generation.Extended));
        }

        public static Vector2N<TNumeric> NextVector2<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector2N<TNumeric>(
                random.NextNumeric<TNumeric>(Generation.Extended),
                random.NextNumeric<TNumeric>(Generation.Extended));
        }

        public static Vector3N<TNumeric> NextVector3<TNumeric>(this Random random) where TNumeric : struct, INumeric<TNumeric>
        {
            return new Vector3N<TNumeric>(
                random.NextNumeric<TNumeric>(Generation.Extended),
                random.NextNumeric<TNumeric>(Generation.Extended),
                random.NextNumeric<TNumeric>(Generation.Extended));
        }

        public static byte NextByte(this Random random)
                => (byte)random.Next(byte.MaxValue);

        public static byte NextByte(this Random random, byte maxValue)
            => (byte)random.Next(maxValue);

        public static byte NextByte(this Random random, byte minValue, byte maxValue)
            => (byte)random.Next(minValue, maxValue);

        public static byte NextByte(this Random random, Generation mode) => mode switch
        {
            Generation.Default => random.NextByte(),
            Generation.Extended => random.NextByteExtended(byte.MinValue, byte.MaxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        public static byte NextByte(this Random random, byte minValue, byte maxValue, Generation mode) => mode switch
        {
            Generation.Default => random.NextByte(minValue, maxValue),
            Generation.Extended => random.NextByteExtended(minValue, maxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [SuppressMessage("Style", "IDE0072:Add missing cases", Justification = "Unreachable")]
        public static byte NextByte(this Random random, Variants variants) => random.ChooseVariant(variants) switch
        {
            Variants.Defaults => default,
            Variants.LowMagnitude => random.NextByte(0, LowMagnitudeByte, Generation.Extended),
            Variants.AnyMagnitude => random.NextByte(Generation.Extended),
            Variants.Boundaries => random.Choose(byte.MinValue, byte.MaxValue),
            Variants.Errors => default,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static sbyte NextSByte(this Random random)
           => (sbyte)random.Next(sbyte.MaxValue);

        [CLSCompliant(false)]
        public static sbyte NextSByte(this Random random, sbyte maxValue)
            => (sbyte)random.Next(maxValue);

        [CLSCompliant(false)]
        public static sbyte NextSByte(this Random random, sbyte minValue, sbyte maxValue)
            => (sbyte)random.Next(minValue, maxValue);

        [CLSCompliant(false)]
        public static sbyte NextSByte(this Random random, Generation mode) => mode switch
        {
            Generation.Default => random.NextSByte(),
            Generation.Extended => random.NextSByteExtended(sbyte.MinValue, sbyte.MaxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [CLSCompliant(false)]
        public static sbyte NextSByte(this Random random, sbyte minValue, sbyte maxValue, Generation mode) => mode switch
        {
            Generation.Default => random.NextSByte(minValue, maxValue),
            Generation.Extended => random.NextSByteExtended(minValue, maxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [CLSCompliant(false)]
        [SuppressMessage("Style", "IDE0072:Add missing cases", Justification = "Unreachable")]
        public static sbyte NextSByte(this Random random, Variants variants) => random.ChooseVariant(variants) switch
        {
            Variants.Defaults => default,
            Variants.LowMagnitude => random.NextSByte(-LowMagnitudeSByte, LowMagnitudeSByte, Generation.Extended),
            Variants.AnyMagnitude => random.NextSByte(Generation.Extended),
            Variants.Boundaries => random.Choose(sbyte.MinValue, sbyte.MaxValue),
            Variants.Errors => default,
            _ => throw new InvalidOperationException(),
        };

        public static short NextInt16(this Random random)
           => (short)random.Next(short.MaxValue);

        public static short NextInt16(this Random random, short maxValue)
            => (short)random.Next(maxValue);

        public static short NextInt16(this Random random, short minValue, short maxValue)
            => (short)random.Next(minValue, maxValue);

        public static short NextInt16(this Random random, Generation mode) => mode switch
        {
            Generation.Default => random.NextInt16(),
            Generation.Extended => random.NextInt16Extended(short.MinValue, short.MaxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        public static short NextInt16(this Random random, short minValue, short maxValue, Generation mode) => mode switch
        {
            Generation.Default => random.NextInt16(minValue, maxValue),
            Generation.Extended => random.NextInt16Extended(minValue, maxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [SuppressMessage("Style", "IDE0072:Add missing cases", Justification = "Unreachable")]
        public static short NextInt16(this Random random, Variants variants) => random.ChooseVariant(variants) switch
        {
            Variants.Defaults => default,
            Variants.LowMagnitude => random.NextInt16(-LowMagnitudeInt16, LowMagnitudeInt16, Generation.Extended),
            Variants.AnyMagnitude => random.NextInt16(Generation.Extended),
            Variants.Boundaries => random.Choose(short.MinValue, short.MaxValue),
            Variants.Errors => default,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ushort NextUInt16(this Random random)
           => (ushort)random.Next(ushort.MaxValue);

        [CLSCompliant(false)]
        public static ushort NextUInt16(this Random random, ushort maxValue)
            => (ushort)random.Next(maxValue);

        [CLSCompliant(false)]
        public static ushort NextUInt16(this Random random, ushort minValue, ushort maxValue)
            => (ushort)random.Next(minValue, maxValue);

        [CLSCompliant(false)]
        public static ushort NextUInt16(this Random random, Generation mode) => mode switch
        {
            Generation.Default => random.NextUInt16(),
            Generation.Extended => random.NextUInt16Extended(ushort.MinValue, ushort.MaxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [CLSCompliant(false)]
        public static ushort NextUInt16(this Random random, ushort minValue, ushort maxValue, Generation mode) => mode switch
        {
            Generation.Default => random.NextUInt16(minValue, maxValue),
            Generation.Extended => random.NextUInt16Extended(minValue, maxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [CLSCompliant(false)]
        [SuppressMessage("Style", "IDE0072:Add missing cases", Justification = "Unreachable")]
        public static ushort NextUInt16(this Random random, Variants variants) => random.ChooseVariant(variants) switch
        {
            Variants.Defaults => default,
            Variants.LowMagnitude => random.NextUInt16(0, LowMagnitudeUInt16, Generation.Extended),
            Variants.AnyMagnitude => random.NextUInt16(Generation.Extended),
            Variants.Boundaries => random.Choose(ushort.MinValue, ushort.MaxValue),
            Variants.Errors => default,
            _ => throw new InvalidOperationException(),
        };

        public static int NextInt32(this Random random)
            => random.Next(0, int.MaxValue); // Use the same overload of Next for consistency

        public static int NextInt32(this Random random, int maxValue)
            => random.Next(0, maxValue); // Use the same overload of Next for consistency

        public static int NextInt32(this Random random, int minValue, int maxValue)
            => random.Next(minValue, maxValue); // Use the same overload of Next for consistency

        public static int NextInt32(this Random random, Generation mode) => mode switch
        {
            Generation.Default => random.Next(0, int.MaxValue), // Use the same overload of Next for consistency
            Generation.Extended => random.NextInt32Extended(int.MinValue, int.MaxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        public static int NextInt32(this Random random, int minValue, int maxValue, Generation mode) => mode switch
        {
            Generation.Default => random.Next(minValue, maxValue), // Use the same overload of Next for consistency
            Generation.Extended => random.NextInt32Extended(minValue, maxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [SuppressMessage("Style", "IDE0072:Add missing cases", Justification = "Unreachable")]
        public static int NextInt32(this Random random, Variants variants) => random.ChooseVariant(variants) switch
        {
            Variants.Defaults => default,
            Variants.LowMagnitude => random.NextInt32(-LowMagnitudeInt32, LowMagnitudeInt32, Generation.Extended),
            Variants.AnyMagnitude => random.NextInt32(Generation.Extended),
            Variants.Boundaries => random.Choose(int.MinValue, int.MaxValue),
            Variants.Errors => default,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static uint NextUInt32(this Random random)
            => random.NextUInt32Default(0, uint.MaxValue);

        [CLSCompliant(false)]
        public static uint NextUInt32(this Random random, uint maxValue)
            => random.NextUInt32Default(0, maxValue);

        [CLSCompliant(false)]
        public static uint NextUInt32(this Random random, uint minValue, uint maxValue)
            => random.NextUInt32Default(minValue, maxValue);

        [CLSCompliant(false)]
        public static uint NextUInt32(this Random random, Generation mode) => mode switch
        {
            Generation.Default => random.NextUInt32Default(0, uint.MaxValue),
            Generation.Extended => random.NextUInt32Extended(uint.MinValue, uint.MaxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [CLSCompliant(false)]
        public static uint NextUInt32(this Random random, uint minValue, uint maxValue, Generation mode) => mode switch
        {
            Generation.Default => random.NextUInt32Default(minValue, maxValue),
            Generation.Extended => random.NextUInt32Extended(minValue, maxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [CLSCompliant(false)]
        [SuppressMessage("Style", "IDE0072:Add missing cases", Justification = "Unreachable")]
        public static uint NextUInt32(this Random random, Variants variants) => random.ChooseVariant(variants) switch
        {
            Variants.Defaults => default,
            Variants.LowMagnitude => random.NextUInt32(0, LowMagnitudeUInt32, Generation.Extended),
            Variants.AnyMagnitude => random.NextUInt32(Generation.Extended),
            Variants.Boundaries => random.Choose(uint.MinValue, uint.MaxValue),
            Variants.Errors => default,
            _ => throw new InvalidOperationException(),
        };

        public static long NextInt64(this Random random)
            => random.NextInt64Default(0, long.MaxValue);

        public static long NextInt64(this Random random, long maxValue)
            => random.NextInt64Default(0, maxValue);

        public static long NextInt64(this Random random, long minValue, long maxValue)
            => random.NextInt64Default(minValue, maxValue);

        public static long NextInt64(this Random random, Generation mode) => mode switch
        {
            Generation.Default => random.NextInt64Default(0, long.MaxValue),
            Generation.Extended => random.NextInt64Extended(long.MinValue, long.MaxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        public static long NextInt64(this Random random, long minValue, long maxValue, Generation mode) => mode switch
        {
            Generation.Default => random.NextInt64Default(minValue, maxValue),
            Generation.Extended => random.NextInt64Extended(minValue, maxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [SuppressMessage("Style", "IDE0072:Add missing cases", Justification = "Unreachable")]
        public static long NextInt64(this Random random, Variants variants) => random.ChooseVariant(variants) switch
        {
            Variants.Defaults => default,
            Variants.LowMagnitude => random.NextInt64(-LowMagnitudeInt64, LowMagnitudeInt64, Generation.Extended),
            Variants.AnyMagnitude => random.NextInt64(Generation.Extended),
            Variants.Boundaries => random.Choose(long.MinValue, long.MaxValue),
            Variants.Errors => default,
            _ => throw new InvalidOperationException(),
        };

        [CLSCompliant(false)]
        public static ulong NextUInt64(this Random random)
            => random.NextUInt64Default(0, ulong.MaxValue);

        [CLSCompliant(false)]
        public static ulong NextUInt64(this Random random, ulong maxValue)
            => random.NextUInt64Default(0, maxValue);

        [CLSCompliant(false)]
        public static ulong NextUInt64(this Random random, ulong minValue, ulong maxValue)
            => random.NextUInt64Default(minValue, maxValue);

        [CLSCompliant(false)]
        public static ulong NextUInt64(this Random random, Generation mode) => mode switch
        {
            Generation.Default => random.NextUInt64Default(0, ulong.MaxValue),
            Generation.Extended => random.NextUInt64Extended(ulong.MinValue, ulong.MaxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [CLSCompliant(false)]
        public static ulong NextUInt64(this Random random, ulong minValue, ulong maxValue, Generation mode) => mode switch
        {
            Generation.Default => random.NextUInt64Default(minValue, maxValue),
            Generation.Extended => random.NextUInt64Extended(minValue, maxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [CLSCompliant(false)]
        [SuppressMessage("Style", "IDE0072:Add missing cases", Justification = "Unreachable")]
        public static ulong NextUInt64(this Random random, Variants variants) => random.ChooseVariant(variants) switch
        {
            Variants.Defaults => default,
            Variants.LowMagnitude => random.NextUInt64(0, LowMagnitudeUInt64, Generation.Extended),
            Variants.AnyMagnitude => random.NextUInt64(Generation.Extended),
            Variants.Boundaries => random.Choose(ulong.MinValue, ulong.MaxValue),
            Variants.Errors => default,
            _ => throw new InvalidOperationException(),
        };

        public static float NextSingle(this Random random)
            => (float)random.NextDouble();

        public static float NextSingle(this Random random, float maxValue)
            => random.NextSingleDefault(0, maxValue);

        public static float NextSingle(this Random random, float minValue, float maxValue)
            => random.NextSingleDefault(minValue, maxValue);

        public static float NextSingle(this Random random, Generation mode) => mode switch
        {
            Generation.Default => (float)random.NextDouble(),
            Generation.Extended => random.NextSingleExtended(float.MinValue, float.MaxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        public static float NextSingle(this Random random, float minValue, float maxValue, Generation mode) => mode switch
        {
            Generation.Default => random.NextSingleDefault(minValue, maxValue),
            Generation.Extended => random.NextSingleExtended(minValue, maxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [SuppressMessage("Style", "IDE0072:Add missing cases", Justification = "Unreachable")]
        public static float NextSingle(this Random random, Variants variants) => random.ChooseVariant(variants) switch
        {
            Variants.Defaults => default,
            Variants.LowMagnitude => MathFShim.Round(random.NextSingle(-LowMagnitudeSingle, LowMagnitudeSingle, Generation.Extended), LowMagnitudeDecimalPlaces),
            Variants.AnyMagnitude => random.NextSingle(Generation.Extended),
            Variants.Boundaries => random.Choose(float.MinValue, float.MaxValue),
            Variants.Errors => random.Choose(default, float.NegativeInfinity, float.PositiveInfinity, float.NaN),
            _ => throw new InvalidOperationException(),
        };

        public static double NextDouble(this Random random)
            => random.NextDouble();

        public static double NextDouble(this Random random, double maxValue)
            => random.NextDoubleDefault(0, maxValue);

        public static double NextDouble(this Random random, double minValue, double maxValue)
            => random.NextDoubleDefault(minValue, maxValue);

        public static double NextDouble(this Random random, Generation mode) => mode switch
        {
            Generation.Default => random.NextDouble(),
            Generation.Extended => random.NextDoubleExtended(double.MinValue, double.MaxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        public static double NextDouble(this Random random, double minValue, double maxValue, Generation mode) => mode switch
        {
            Generation.Default => random.NextDoubleDefault(minValue, maxValue),
            Generation.Extended => random.NextDoubleExtended(minValue, maxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [SuppressMessage("Style", "IDE0072:Add missing cases", Justification = "Unreachable")]
        public static double NextDouble(this Random random, Variants variants) => random.ChooseVariant(variants) switch
        {
            Variants.Defaults => default,
            Variants.LowMagnitude => Math.Round(random.NextDouble(-LowMagnitudeDouble, LowMagnitudeDouble, Generation.Extended), LowMagnitudeDecimalPlaces),
            Variants.AnyMagnitude => random.NextDouble(Generation.Extended),
            Variants.Boundaries => random.Choose(double.MinValue, double.MaxValue),
            Variants.Errors => random.Choose(default, double.NegativeInfinity, double.PositiveInfinity, double.NaN),
            _ => throw new InvalidOperationException(),
        };

        public static decimal NextDecimal(this Random random)
            => random.NextDecimalDefault(0, decimal.MaxValue);

        public static decimal NextDecimal(this Random random, decimal maxValue)
            => random.NextDecimalDefault(0, maxValue);

        public static decimal NextDecimal(this Random random, decimal minValue, decimal maxValue)
            => random.NextDecimalDefault(minValue, maxValue);

        public static decimal NextDecimal(this Random random, Generation mode) => mode switch
        {
            Generation.Default => random.NextDecimalDefault(0, decimal.MaxValue),
            Generation.Extended => random.NextDecimalExtended(decimal.MinValue, decimal.MaxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        public static decimal NextDecimal(this Random random, decimal minValue, decimal maxValue, Generation mode) => mode switch
        {
            Generation.Default => random.NextDecimalDefault(minValue, maxValue),
            Generation.Extended => random.NextDecimalExtended(minValue, maxValue),
            _ => throw new ArgumentException(string.Format(InvalidGenerationValue, mode), nameof(mode)),
        };

        [SuppressMessage("Style", "IDE0072:Add missing cases", Justification = "Unreachable")]
        public static decimal NextDecimal(this Random random, Variants variants) => random.ChooseVariant(variants) switch
        {
            Variants.Defaults => default,
            Variants.LowMagnitude => Math.Round(random.NextDecimal(-LowMagnitudeDecimal, LowMagnitudeDecimal, Generation.Extended), LowMagnitudeDecimalPlaces),
            Variants.AnyMagnitude => random.NextDecimal(Generation.Extended),
            Variants.Boundaries => random.Choose(decimal.MinValue, decimal.MaxValue),
            Variants.Errors => default,
            _ => throw new InvalidOperationException(),
        };

        private static byte NextByteExtended(this Random random, byte bound1, byte bound2)
        {
            if (bound1 == bound2) return bound1;
            if (bound1 > bound2) return (byte)random.Next(bound2, bound1 + 1);
            return (byte)random.Next(bound1, bound2 + 1);
        }

        private static sbyte NextSByteExtended(this Random random, sbyte bound1, sbyte bound2)
        {
            if (bound1 == bound2) return bound1;
            if (bound1 > bound2) return (sbyte)random.Next(bound2, bound1 + 1);
            return (sbyte)random.Next(bound1, bound2 + 1);
        }

        private static short NextInt16Extended(this Random random, short bound1, short bound2)
        {
            if (bound1 == bound2) return bound1;
            if (bound1 > bound2) return (short)random.Next(bound2, bound1 + 1);
            return (short)random.Next(bound1, bound2 + 1);
        }

        private static ushort NextUInt16Extended(this Random random, ushort bound1, ushort bound2)
        {
            if (bound1 == bound2) return bound1;
            if (bound1 > bound2) return (ushort)random.Next(bound2, bound1 + 1);
            return (ushort)random.Next(bound1, bound2 + 1);
        }

        private static int NextInt32Extended(this Random random, int bound1, int bound2)
        {
            if (bound1 == bound2) return bound1;

            if (bound1 > bound2) ValueTupleShim.Swap(ref bound1, ref bound2);

            if (bound2 != int.MaxValue) return random.Next(bound1, bound2 + 1);

            if (bound1 != int.MinValue) return random.Next(bound1 - 1, bound2) + 1;

            byte[] bytes = new byte[4];

            random.NextBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        private static uint NextUInt32Default(this Random random, uint minValue, uint maxValue)
        {
            if (minValue == maxValue) return minValue;
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue,
                string.Format(XCannotBeGreaterThanY, nameof(minValue), nameof(maxValue)));

            uint spread = maxValue - minValue;

            if (spread <= int.MaxValue) return minValue + (uint)random.Next((int)spread);

            byte[] bytes = new byte[4];
            uint result;
            do
            {
                random.NextBytes(bytes);
                result = BitConverter.ToUInt32(bytes, 0);
            } while (result < minValue || result >= maxValue); // ~1 in 2 chance.
            return result;
        }

        private static uint NextUInt32Extended(this Random random, uint bound1, uint bound2)
        {
            if (bound1 == bound2) return bound1;
            if (bound1 > bound2) ValueTupleShim.Swap(ref bound1, ref bound2);

            uint spread = bound2 - bound1;

            if (spread < int.MaxValue) return bound1 + (uint)random.Next((int)spread + 1);

            byte[] bytes = new byte[4];
            uint result;
            do
            {
                random.NextBytes(bytes);
                result = BitConverter.ToUInt32(bytes, 0);
            } while (result < bound1 || result > bound2); // ~1 in 2 chance.
            return result;
        }

        private static long NextInt64Default(this Random random, long minValue, long maxValue)
        {
            if (minValue == maxValue) return minValue;
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue,
                string.Format(XCannotBeGreaterThanY, nameof(minValue), nameof(maxValue)));

            BigInteger spread = (BigInteger)maxValue - minValue;

            if (spread <= int.MaxValue) return minValue + random.Next((int)spread);

            byte[] bytes = spread.ToByteArray();
            BigInteger result;
            do
            {
                random.NextBytes(bytes);
                result = new BigInteger(bytes);
            } while (result < 0 || result > spread);
            return (long)(minValue + result);
        }

        private static long NextInt64Extended(this Random random, long bound1, long bound2)
        {
            if (bound1 == bound2) return bound1;
            if (bound1 > bound2) ValueTupleShim.Swap(ref bound1, ref bound2);

            BigInteger spread = (BigInteger)bound2 - bound1;

            if (spread < int.MaxValue) return bound1 + random.Next((int)spread + 1);

            BigInteger bitMask = BigInteger.Pow(2, (int)Math.Ceiling(BigInteger.Log(spread, 2))) - 1;

            byte[] bytes = spread.ToByteArray();
            BigInteger result;
            do
            {
                random.NextBytes(bytes);
                result = new BigInteger(bytes) & bitMask;
            } while (result < 0 || result > spread);
            return (long)(bound1 + result);
        }

        private static ulong NextUInt64Default(this Random random, ulong minValue, ulong maxValue)
        {
            if (minValue == maxValue) return minValue;
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue,
                string.Format(XCannotBeGreaterThanY, nameof(minValue), nameof(maxValue)));

            ulong spread = maxValue - minValue;

            if (spread <= int.MaxValue) return minValue + (ulong)random.Next((int)spread);

            byte[] bytes = new byte[8];
            ulong result;
            do
            {
                random.NextBytes(bytes);
                result = BitConverter.ToUInt64(bytes, 0);
            } while (result > spread);
            return minValue + result;
        }

        private static ulong NextUInt64Extended(this Random random, ulong bound1, ulong bound2)
        {
            if (bound1 == bound2) return bound1;
            if (bound1 > bound2) ValueTupleShim.Swap(ref bound1, ref bound2);

            BigInteger spread = (BigInteger)bound2 - bound1;

            if (spread < int.MaxValue) return bound1 + (ulong)random.Next((int)spread + 1);

            byte[] bytes = spread.ToByteArray();
            BigInteger result;
            do
            {
                random.NextBytes(bytes);
                result = new BigInteger(bytes);
            } while (result < 0 || result > spread);
            return (ulong)(bound1 + result);
        }

        private static float NextSingleDefault(this Random random, float minValue, float maxValue)
        {
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, string.Format(XCannotBeGreaterThanY, nameof(minValue), nameof(maxValue)));
            if (!SingleShim.IsFinite(minValue)) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, string.Format(XMustBeFinite, nameof(minValue)));
            if (!SingleShim.IsFinite(maxValue)) throw new ArgumentOutOfRangeException(nameof(maxValue), maxValue, string.Format(XMustBeFinite, nameof(minValue)));

            if (minValue == maxValue) return minValue;

            return minValue + ((float)random.NextDouble() * (maxValue - minValue));
        }

        private static float NextSingleExtended(this Random random, float bound1, float bound2)
        {
            if (!SingleShim.IsFinite(bound1)) throw new ArgumentOutOfRangeException(nameof(bound1), bound1, string.Format(XMustBeFinite, nameof(bound1)));
            if (!SingleShim.IsFinite(bound2)) throw new ArgumentOutOfRangeException(nameof(bound2), bound2, string.Format(XMustBeFinite, nameof(bound1)));

            if (bound1 == bound2) return bound1;

            ValueTupleShim.Swap(bound1 > bound2, ref bound1, ref bound2);

            int bound1Bits = BitConverterShim.SingleToInt32Bits(bound1);
            int bound2Bits = BitConverterShim.SingleToInt32Bits(bound2);

            int resultBitValue = random.Next(
                bound1Bits < 0 ? int.MinValue - bound1Bits : bound1Bits,
                (bound2Bits < 0 ? int.MinValue - bound2Bits : bound2Bits) + 1);

            float result = BitConverterShim.Int32BitsToSingle(resultBitValue < 0 ? int.MinValue - resultBitValue : resultBitValue);

            return result;
        }

        private static double NextDoubleDefault(this Random random, double minValue, double maxValue)
        {
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, string.Format(XCannotBeGreaterThanY, nameof(minValue), nameof(maxValue)));
            if (!DoubleShim.IsFinite(minValue)) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, string.Format(XMustBeFinite, nameof(minValue)));
            if (!DoubleShim.IsFinite(maxValue)) throw new ArgumentOutOfRangeException(nameof(maxValue), maxValue, string.Format(XMustBeFinite, nameof(minValue)));

            if (minValue == maxValue) return minValue;

            return minValue + (random.NextDouble() * (maxValue - minValue));
        }

        private static double NextDoubleExtended(this Random random, double bound1, double bound2)
        {
            if (!DoubleShim.IsFinite(bound1)) throw new ArgumentOutOfRangeException(nameof(bound1), bound1, string.Format(XMustBeFinite, nameof(bound1)));
            if (!DoubleShim.IsFinite(bound2)) throw new ArgumentOutOfRangeException(nameof(bound2), bound2, string.Format(XMustBeFinite, nameof(bound1)));

            if (bound1 == bound2) return bound1;

            ValueTupleShim.Swap(bound1 > bound2, ref bound1, ref bound2);

            long bound1Bits = BitConverterShim.DoubleToInt64Bits(bound1);
            long bound2Bits = BitConverterShim.DoubleToInt64Bits(bound2);

            long resultBitValue = random.NextInt64(
                bound1Bits < 0 ? long.MinValue - bound1Bits : bound1Bits,
                bound2Bits < 0 ? long.MinValue - bound2Bits : bound2Bits,
                Generation.Extended);

            double result = BitConverterShim.Int64BitsToDouble(resultBitValue < 0 ? long.MinValue - resultBitValue : resultBitValue);

            return result;
        }

        private static decimal NextDecimalDefault(this Random random, decimal minValue, decimal maxValue)
        {
            if (minValue > maxValue) throw new ArgumentOutOfRangeException(nameof(minValue), minValue, string.Format(XCannotBeGreaterThanY, nameof(minValue), nameof(maxValue)));

            if (minValue == maxValue) return minValue;

            return minValue + ((decimal)random.NextDouble() * (maxValue - minValue));
        }

        private static decimal NextDecimalExtended(this Random random, decimal minValue, decimal maxValue)
        {
            if (minValue == maxValue) return minValue;
            ValueTupleShim.Swap(minValue > maxValue, ref minValue, ref maxValue);

            decimal difference;
            try
            {
                checked { difference = maxValue - minValue; }

                decimal scalar = (decimal)(random.Next() / (1.0 * (int.MaxValue - 1)));
                decimal result = minValue + (difference * scalar);
                return result;
            }
            catch (OverflowException)
            {
                decimal result;
                do
                {
                    result = new decimal(
                        random.NextInt32(),
                        random.NextInt32(),
                        random.NextInt32(),
                        random.NextBoolean(),
                        random.NextByte(28));
                } while (result < minValue || result > maxValue);
                return result;
            }
        }

        private static Variants ChooseVariant(this Random random, Variants variants)
        {
            int count = CountFlags(variants);
            if (count == 0) throw new ArgumentOutOfRangeException(nameof(variants));

            int index = random.Next(0, count);

            if (variants.HasFlag(Variants.Defaults) && index-- == 0) return Variants.Defaults;
            if (variants.HasFlag(Variants.LowMagnitude) && index-- == 0) return Variants.LowMagnitude;
            if (variants.HasFlag(Variants.AnyMagnitude) && index-- == 0) return Variants.AnyMagnitude;
            if (variants.HasFlag(Variants.Boundaries) && index-- == 0) return Variants.Boundaries;
            if (variants.HasFlag(Variants.Errors) && index == 0) return Variants.Errors;

            throw new InvalidOperationException();
        }

        private static int CountFlags(Variants variants)
        {
            return (HasFlag(variants, Variants.Defaults) ? 1 : 0) +
                (HasFlag(variants, Variants.LowMagnitude) ? 1 : 0) +
                (HasFlag(variants, Variants.AnyMagnitude) ? 1 : 0) +
                (HasFlag(variants, Variants.Boundaries) ? 1 : 0) +
                (HasFlag(variants, Variants.Errors) ? 1 : 0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool HasFlag(Variants variants, Variants flag) => ((byte)variants & (byte)flag) > 0;
    }
}
