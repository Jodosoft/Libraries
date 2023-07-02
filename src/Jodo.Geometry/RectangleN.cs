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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Geometry
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct RectangleN<TNumeric> :
            IEquatable<RectangleN<TNumeric>>,
            IFormattable,
            IProvider<IBinaryIO<RectangleN<TNumeric>>>,
            IProvider<IVariantRandom<RectangleN<TNumeric>>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        public readonly Vector2N<TNumeric> Center;
        public readonly Vector2N<TNumeric> Dimensions;
        public readonly AngleN<TNumeric> Angle;

        public TNumeric Height => Dimensions.Y;
        public TNumeric Width => Dimensions.X;

        public RectangleN(Vector2N<TNumeric> origin, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle)
        {
            Center = origin;
            Dimensions = dimensions;
            Angle = angle;
        }

        private RectangleN(SerializationInfo info, StreamingContext context)
        {
            Center = (Vector2N<TNumeric>)info.GetValue(nameof(Center), typeof(Vector2N<TNumeric>));
            Dimensions = (Vector2N<TNumeric>)info.GetValue(nameof(Dimensions), typeof(Vector2N<TNumeric>));
            Angle = (AngleN<TNumeric>)info.GetValue(nameof(Angle), typeof(AngleN<TNumeric>));
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Center), Center, typeof(Vector2N<TNumeric>));
            info.AddValue(nameof(Dimensions), Dimensions, typeof(Vector2N<TNumeric>));
            info.AddValue(nameof(Angle), Angle, typeof(AngleN<TNumeric>));
        }

        public bool Contains(RectangleN<TNumeric> other)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Vector2N<TNumeric> point)
        {
            throw new NotImplementedException();
        }

        public bool IntersectsWith(RectangleN<TNumeric> other)
        {
            throw new NotImplementedException();
        }

        public TNumeric GetArea() => MathN.Abs(Width.Multiply(Height));

        public RectangleN<TNumeric> Grow(TNumeric delta) => Grow(new Vector2N<TNumeric>(delta, delta));
        public RectangleN<TNumeric> Grow(TNumeric deltaX, TNumeric deltaY) => Grow(new Vector2N<TNumeric>(deltaX, deltaY));
        public RectangleN<TNumeric> Grow(Vector2N<TNumeric> delta) => new RectangleN<TNumeric>(Center, Dimensions + delta, Angle);

        public RectangleN<TNumeric> Scale(TNumeric scale) => new RectangleN<TNumeric>(Center, Dimensions * scale, Angle);

        public RectangleN<TNumeric> Rotate(AngleN<TNumeric> angle) => new RectangleN<TNumeric>(Center, Dimensions, Angle + angle);
        public RectangleN<TNumeric> RotateAround(Vector2N<TNumeric> pivot, AngleN<TNumeric> angle) => new RectangleN<TNumeric>(Center.RotateAround(pivot, angle), Dimensions, Angle + angle);
        public RectangleN<TNumeric> Shrink(TNumeric delta) => Shrink(new Vector2N<TNumeric>(delta, delta));
        public RectangleN<TNumeric> Shrink(TNumeric deltaX, TNumeric deltaY) => Shrink(new Vector2N<TNumeric>(deltaX, deltaY));
        public RectangleN<TNumeric> Shrink(Vector2N<TNumeric> delta) => new RectangleN<TNumeric>(Center, Dimensions - delta, Angle);
        public RectangleN<TNumeric> Translate(TNumeric deltaX, TNumeric deltaY) => Translate(new Vector2N<TNumeric>(deltaX, deltaY));
        public RectangleN<TNumeric> Translate(Vector2N<TNumeric> delta) => new RectangleN<TNumeric>(Center + delta, Dimensions, Angle);
        public RectangleN<TNumeric> UnitTranslate(TNumeric deltaX, TNumeric deltaY) => Translate(new Vector2N<TNumeric>(deltaX, deltaY));
        public RectangleN<TNumeric> UnitTranslate(Vector2N<TNumeric> delta) => new RectangleN<TNumeric>(
            Center + new Vector2N<TNumeric>(delta.X.Multiply(Width), delta.Y.Multiply(Height)), Dimensions, Angle);

        public bool Equals(RectangleN<TNumeric> other) => Center.Equals(other.Center) && Dimensions.Equals(other.Dimensions) && Angle.Equals(other.Angle);
        public override bool Equals(object? obj)
        {
            return obj is RectangleN<TNumeric> rectangle && Equals(rectangle);
        }

        public override int GetHashCode() => HashCodeShim.Combine(Center, Dimensions, Angle);
        public override string ToString() => $"<X:{Center.X}, Y:{Center.Y}, W:{Dimensions.X}, H:{Dimensions.Y}, A:{Angle}>";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"<X:{Center.X.ToString(format, formatProvider)}, Y:{Center.Y.ToString(format, formatProvider)}, W:{Dimensions.X.ToString(format, formatProvider)}, H:{Dimensions.Y.ToString(format, formatProvider)}, A:{Angle.ToString(format, formatProvider)}>";

        public AARectangleN<TNumeric> GetBounds()
        {
            TNumeric[]? xs = new[] { this.GetTopLeft().X, this.GetTopRight().X, this.GetBottomLeft().X, this.GetBottomRight().X };
            TNumeric[]? ys = new[] { this.GetTopLeft().Y, this.GetTopRight().Y, this.GetBottomLeft().Y, this.GetBottomRight().Y };

            TNumeric minX = xs.Min();
            TNumeric maxX = xs.Max();
            TNumeric minY = ys.Min();
            TNumeric maxY = ys.Max();

            Vector2N<TNumeric> dimensions = new Vector2N<TNumeric>(maxX.Subtract(minX), maxY.Subtract(minY));
            return AARectangleN.FromBottomLeft(new Vector2N<TNumeric>(minX, minY), dimensions);
        }

        public static bool operator ==(RectangleN<TNumeric> left, RectangleN<TNumeric> right) => left.Equals(right);
        public static bool operator !=(RectangleN<TNumeric> left, RectangleN<TNumeric> right) => !(left == right);
        public static implicit operator RectangleN<TNumeric>(AARectangleN<TNumeric> value) => new RectangleN<TNumeric>(value.Center, value.Dimensions, default);

        IBinaryIO<RectangleN<TNumeric>> IProvider<IBinaryIO<RectangleN<TNumeric>>>.GetInstance() => Utilities.Instance;
        IVariantRandom<RectangleN<TNumeric>> IProvider<IVariantRandom<RectangleN<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBinaryIO<RectangleN<TNumeric>>,
           IVariantRandom<RectangleN<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            void IBinaryIO<RectangleN<TNumeric>>.Write(BinaryWriter writer, RectangleN<TNumeric> value)
            {
                writer.Write(value.Center);
                writer.Write(value.Dimensions);
                writer.Write(value.Angle);
            }

            RectangleN<TNumeric> IBinaryIO<RectangleN<TNumeric>>.Read(BinaryReader reader)
            {
                return new RectangleN<TNumeric>(
                    reader.Read<Vector2N<TNumeric>>(),
                    reader.Read<Vector2N<TNumeric>>(),
                    reader.Read<AngleN<TNumeric>>());
            }

            RectangleN<TNumeric> IVariantRandom<RectangleN<TNumeric>>.Generate(Random random, Variants variants)
            {
                return new RectangleN<TNumeric>(
                    random.NextVariant<Vector2N<TNumeric>>(variants),
                    random.NextVariant<Vector2N<TNumeric>>(variants),
                    random.NextVariant<AngleN<TNumeric>>(variants));
            }
        }
    }

    public static class RectangleN
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectangleN<TNumeric> FromCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new RectangleN<TNumeric>(center, dimensions, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectangleN<TNumeric> FromBottomLeft<TNumeric>(Vector2N<TNumeric> bottomLeft, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new RectangleN<TNumeric>(GetCenterFromBottomLeft(bottomLeft, dimensions, angle), dimensions, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectangleN<TNumeric> FromBottomCenter<TNumeric>(Vector2N<TNumeric> bottomCenter, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new RectangleN<TNumeric>(GetCenterFromBottomCenter(bottomCenter, dimensions, angle), dimensions, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectangleN<TNumeric> FromBottomRight<TNumeric>(Vector2N<TNumeric> bottomRight, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new RectangleN<TNumeric>(GetCenterFromBottomRight(bottomRight, dimensions, angle), dimensions, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectangleN<TNumeric> FromLeftCenter<TNumeric>(Vector2N<TNumeric> leftCenter, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new RectangleN<TNumeric>(GetCenterFromLeftCenter(leftCenter, dimensions, angle), dimensions, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectangleN<TNumeric> FromRightCenter<TNumeric>(Vector2N<TNumeric> rightCenter, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new RectangleN<TNumeric>(GetCenterFromRightCenter(rightCenter, dimensions, angle), dimensions, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectangleN<TNumeric> FromTopLeft<TNumeric>(Vector2N<TNumeric> topLeft, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new RectangleN<TNumeric>(GetCenterFromTopLeft(topLeft, dimensions, angle), dimensions, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectangleN<TNumeric> FromTopCenter<TNumeric>(Vector2N<TNumeric> topCenter, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new RectangleN<TNumeric>(GetCenterFromTopCenter(topCenter, dimensions, angle), dimensions, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static RectangleN<TNumeric> FromTopRight<TNumeric>(Vector2N<TNumeric> topRight, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return new RectangleN<TNumeric>(GetCenterFromTopRight(topRight, dimensions, angle), dimensions, angle);
        }

        public static RectangleN<TNumeric> Parse<TNumeric>(string s, NumberStyles? style, IFormatProvider? provider) where TNumeric : struct, INumeric<TNumeric>
        {
            string[] parts = StringUtilities.ParseVectorParts(s.Trim());
            if (parts.Length == 5)
                return new RectangleN<TNumeric>(
                    new Vector2N<TNumeric>(
                        Numeric.Parse<TNumeric>(parts[0].Replace("X:", string.Empty).Trim(), style, provider),
                        Numeric.Parse<TNumeric>(parts[1].Replace("Y:", string.Empty).Trim(), style, provider)),
                    new Vector2N<TNumeric>(
                        Numeric.Parse<TNumeric>(parts[2].Replace("W:", string.Empty).Trim(), style, provider),
                        Numeric.Parse<TNumeric>(parts[3].Replace("H:", string.Empty).Trim(), style, provider)),
                    AngleN.Parse<TNumeric>(parts[4].Replace("A:", string.Empty).Trim(), style, provider));
            else throw new FormatException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetBottomCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetBottomCenter(center, dimensions).RotateAround(center, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetBottomLeft<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetBottomLeft(center, dimensions).RotateAround(center, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetBottomRight<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetBottomRight(center, dimensions).RotateAround(center, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetLeftCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetLeftCenter(center, dimensions).RotateAround(center, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetRightCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetRightCenter(center, dimensions).RotateAround(center, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetTopCenter<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetTopCenter(center, dimensions).RotateAround(center, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetTopLeft<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetTopLeft(center, dimensions).RotateAround(center, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetTopRight<TNumeric>(Vector2N<TNumeric> center, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetTopRight(center, dimensions).RotateAround(center, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromBottomCenter<TNumeric>(Vector2N<TNumeric> bottomCenter, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetCenterFromBottomCenter(bottomCenter, dimensions).RotateAround(bottomCenter, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromBottomLeft<TNumeric>(Vector2N<TNumeric> bottomLeft, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetCenterFromBottomLeft(bottomLeft, dimensions).RotateAround(bottomLeft, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromBottomRight<TNumeric>(Vector2N<TNumeric> bottomRight, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetCenterFromBottomRight(bottomRight, dimensions).RotateAround(bottomRight, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromLeftCenter<TNumeric>(Vector2N<TNumeric> leftCenter, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetCenterFromLeftCenter(leftCenter, dimensions).RotateAround(leftCenter, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromRightCenter<TNumeric>(Vector2N<TNumeric> rightCenter, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetCenterFromRightCenter(rightCenter, dimensions).RotateAround(rightCenter, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromTopCenter<TNumeric>(Vector2N<TNumeric> topCenter, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetCenterFromTopCenter(topCenter, dimensions).RotateAround(topCenter, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromTopLeft<TNumeric>(Vector2N<TNumeric> topLeft, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetCenterFromTopLeft(topLeft, dimensions).RotateAround(topLeft, angle);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Vector2N<TNumeric> GetCenterFromTopRight<TNumeric>(Vector2N<TNumeric> topRight, Vector2N<TNumeric> dimensions, AngleN<TNumeric> angle) where TNumeric : struct, INumeric<TNumeric>
        {
            return AARectangleN.GetCenterFromTopRight(topRight, dimensions).RotateAround(topRight, angle);
        }
    }
}
