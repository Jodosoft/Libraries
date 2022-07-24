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
using System.Runtime.Serialization;
using Jodo.Numerics;
using Jodo.Primitives;
using Jodo.Primitives.Compatibility;

namespace Jodo.Geometry
{
    [Serializable]
    [DebuggerDisplay("{ToString(),nq}")]
    public readonly struct AARectangle<TNumeric> :
            IEquatable<AARectangle<TNumeric>>,
            IFormattable,
            IProvider<IBitConverter<AARectangle<TNumeric>>>,
            IProvider<IRandom<AARectangle<TNumeric>>>,
            IProvider<IStringParser<AARectangle<TNumeric>>>,
            ITwoDimensional<AARectangle<TNumeric>, TNumeric>,
            IRotatable<Rectangle<TNumeric>, Angle<TNumeric>, Vector2<TNumeric>>,
            ISerializable
        where TNumeric : struct, INumeric<TNumeric>
    {
        private const string Symbol = "□";

        public readonly Vector2<TNumeric> Origin;
        public readonly Vector2<TNumeric> Dimensions;
        public TNumeric Height => Dimensions.Y;
        public TNumeric Width => Dimensions.X;

        public TNumeric GetBottom() => Origin.Y;
        public TNumeric GetLeft() => Origin.X;
        public TNumeric GetRight() => Origin.X.Add(Dimensions.X);
        public TNumeric GetTop() => Origin.Y.Add(Dimensions.Y);
        public Vector2<TNumeric> GetCenter() => AARectangle.GetCenter(Origin, Dimensions);
        public Vector2<TNumeric> GetBottomCenter() => AARectangle.GetBottomCenter(Origin, Dimensions);
        public Vector2<TNumeric> GetBottomLeft() => Origin;
        public Vector2<TNumeric> GetBottomRight() => AARectangle.GetBottomRight(Origin, Dimensions);
        public Vector2<TNumeric> GetLeftCenter() => AARectangle.GetLeftCenter(Origin, Dimensions);
        public Vector2<TNumeric> GetRightCenter() => AARectangle.GetRightCenter(Origin, Dimensions);
        public Vector2<TNumeric> GetTopCenter() => AARectangle.GetTopCenter(Origin, Dimensions);
        public Vector2<TNumeric> GetTopLeft() => AARectangle.GetTopLeft(Origin, Dimensions);
        public Vector2<TNumeric> GetTopRight() => AARectangle.GetTopRight(Origin, Dimensions);

        public AARectangle(Vector2<TNumeric> origin, Vector2<TNumeric> dimensions)
        {
            Origin = origin;
            Dimensions = dimensions;
        }

        public AARectangle(TNumeric originX, TNumeric originY, TNumeric width, TNumeric height)
        {
            Origin = new Vector2<TNumeric>(originX, originY);
            Dimensions = new Vector2<TNumeric>(width, height);
        }

        private AARectangle(SerializationInfo info, StreamingContext context) : this(
            (Vector2<TNumeric>)info.GetValue(nameof(Origin), typeof(Vector2<TNumeric>)),
            (Vector2<TNumeric>)info.GetValue(nameof(Dimensions), typeof(Vector2<TNumeric>)))
        { }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Origin), Origin, typeof(Vector2<TNumeric>));
            info.AddValue(nameof(Dimensions), Dimensions, typeof(Vector2<TNumeric>));
        }

        public TNumeric GetArea() => MathN.Abs(Dimensions.X.Multiply(Dimensions.Y));
        public Vector2<TNumeric>[] GetVertices() => new[] { GetBottomLeft(), GetBottomRight(), GetTopRight(), GetTopLeft() };

        public AARectangle<TNumeric> Grow(Vector2<TNumeric> delta) => new AARectangle<TNumeric>(Origin, Dimensions + delta);
        public AARectangle<TNumeric> Grow(TNumeric deltaX, TNumeric deltaY) => Grow(new Vector2<TNumeric>(deltaX, deltaY));
        public AARectangle<TNumeric> Grow(TNumeric delta) => Grow(new Vector2<TNumeric>(delta, delta));
        public AARectangle<TNumeric> Shrink(Vector2<TNumeric> delta) => new AARectangle<TNumeric>(Origin, Dimensions - delta);
        public AARectangle<TNumeric> Shrink(TNumeric deltaX, TNumeric deltaY) => Shrink(new Vector2<TNumeric>(deltaX, deltaY));
        public AARectangle<TNumeric> Shrink(TNumeric delta) => Shrink(new Vector2<TNumeric>(delta, delta));
        public AARectangle<TNumeric> Translate(Vector2<TNumeric> delta) => new AARectangle<TNumeric>(Origin + delta, Dimensions);

        public bool Contains(Vector2<TNumeric> point) =>
            point.X.IsGreaterThanOrEqualTo(GetLeft()) &&
            point.X.IsLessThanOrEqualTo(GetRight()) &&
            point.Y.IsGreaterThanOrEqualTo(GetBottom()) &&
            point.Y.IsLessThanOrEqualTo(GetTop());

        public bool Contains(AARectangle<TNumeric> other) =>
            GetLeft().IsLessThanOrEqualTo(other.GetLeft()) &&
            GetRight().IsGreaterThanOrEqualTo(other.GetRight()) &&
            GetBottom().IsLessThanOrEqualTo(other.GetBottom()) &&
            GetTop().IsGreaterThanOrEqualTo(other.GetTop());

        public bool IntersectsWith(AARectangle<TNumeric> other) =>
            GetLeft().IsLessThan(other.GetRight()) &&
            GetRight().IsGreaterThan(other.GetLeft()) &&
            GetBottom().IsLessThan(other.GetTop()) &&
            GetTop().IsGreaterThan(other.GetBottom());

        public AARectangle<TNumeric> RotateRight() => new AARectangle<TNumeric>(Origin, new Vector2<TNumeric>(Dimensions.Y, Dimensions.X));
        public Rectangle<TNumeric> Rotate(Angle<TNumeric> angle) => new Rectangle<TNumeric>(Origin, Dimensions, angle);
        public Rectangle<TNumeric> RotateAround(Vector2<TNumeric> pivot, Angle<TNumeric> angle) => new Rectangle<TNumeric>(Origin.RotateAround(pivot, angle), Dimensions, angle);

        public AARectangle<TOther> Convert<TOther>(Func<TNumeric, TOther> convert) where TOther : struct, INumeric<TOther> => new AARectangle<TOther>(convert(Origin.X), convert(Origin.Y), convert(Dimensions.X), convert(Dimensions.Y));
        public bool Equals(AARectangle<TNumeric> other) => Origin.Equals(other.Origin) && Dimensions.Equals(other.Dimensions);
        public override bool Equals(object? obj) => obj is AARectangle<TNumeric> fix && Equals(fix);
        public override int GetHashCode() => HashCode.Combine(Origin, Dimensions);
        public override string ToString() => $"{Symbol}({Origin}, {Dimensions})";
        public string ToString(string? format, IFormatProvider? formatProvider) => $"{Symbol}({Origin.ToString(format, formatProvider)}, {Dimensions.ToString(format, formatProvider)})";

        public static bool operator ==(AARectangle<TNumeric> left, AARectangle<TNumeric> right) => left.Equals(right);
        public static bool operator !=(AARectangle<TNumeric> left, AARectangle<TNumeric> right) => !(left == right);

#if NETSTANDARD2_0_OR_GREATER
        public static implicit operator AARectangle<TNumeric>((Vector2<TNumeric>, Vector2<TNumeric>) value) => new AARectangle<TNumeric>(value.Item1, value.Item2);
        public static implicit operator (Vector2<TNumeric>, Vector2<TNumeric>)(AARectangle<TNumeric> value) => (value.Origin, value.Dimensions);
        public static implicit operator AARectangle<TNumeric>((TNumeric, TNumeric, TNumeric, TNumeric) value) => new AARectangle<TNumeric>((value.Item1, value.Item2), (value.Item3, value.Item4));
        public static implicit operator (TNumeric, TNumeric, TNumeric, TNumeric)(AARectangle<TNumeric> value) => (value.Origin.X, value.Origin.Y, value.Dimensions.X, value.Dimensions.Y);
#endif

        Vector2<TNumeric> ITwoDimensional<AARectangle<TNumeric>, TNumeric>.GetCenter() => GetCenter();
        AARectangle<TNumeric> ITwoDimensional<AARectangle<TNumeric>, TNumeric>.GetBounds() => this;
        Vector2<TNumeric>[] ITwoDimensional<AARectangle<TNumeric>, TNumeric>.GetVertices(int circumferenceDivisor) => GetVertices();

        IBitConverter<AARectangle<TNumeric>> IProvider<IBitConverter<AARectangle<TNumeric>>>.GetInstance() => Utilities.Instance;
        IRandom<AARectangle<TNumeric>> IProvider<IRandom<AARectangle<TNumeric>>>.GetInstance() => Utilities.Instance;
        IStringParser<AARectangle<TNumeric>> IProvider<IStringParser<AARectangle<TNumeric>>>.GetInstance() => Utilities.Instance;

        private sealed class Utilities :
           IBitConverter<AARectangle<TNumeric>>,
           IRandom<AARectangle<TNumeric>>,
           IStringParser<AARectangle<TNumeric>>
        {
            public static readonly Utilities Instance = new Utilities();

            AARectangle<TNumeric> IRandom<AARectangle<TNumeric>>.Next(Random random)
            {
                do
                {
                    try
                    {
                        return checked(AARectangle.Between(
                            random.NextVector2<TNumeric>(),
                            random.NextVector2<TNumeric>()));
                    }
                    catch (OverflowException)
                    {
                        // Try again
                    }
                } while (true);
            }

            AARectangle<TNumeric> IRandom<AARectangle<TNumeric>>.Next(Random random, AARectangle<TNumeric> bound1, AARectangle<TNumeric> bound2)
            {
                TNumeric xMin = MathN.Min(bound1.GetBottomLeft().X, bound2.GetBottomLeft().X);
                TNumeric xMax = MathN.Max(bound1.GetTopRight().X, bound2.GetTopRight().X);
                TNumeric yMin = MathN.Min(bound1.GetBottomLeft().Y, bound2.GetBottomLeft().Y);
                TNumeric yMax = MathN.Max(bound1.GetTopRight().Y, bound2.GetTopRight().Y);
                Vector2<TNumeric> point1 = new Vector2<TNumeric>(random.NextNumeric(xMin, xMax), random.NextNumeric(yMin, yMax));
                Vector2<TNumeric> point2 = new Vector2<TNumeric>(random.NextNumeric(xMin, xMax), random.NextNumeric(yMin, yMax));
                return AARectangle.Between(point1, point2);
            }

            AARectangle<TNumeric> IStringParser<AARectangle<TNumeric>>.Parse(string s, NumberStyles? style, IFormatProvider? provider)
            {
                string[] parts = StringUtilities.ParseVectorParts(s.Replace(Symbol, string.Empty));
                if (parts.Length == 2)
                    return new AARectangle<TNumeric>(
                        StringParser.Parse<Vector2<TNumeric>>(parts[0], style, provider),
                        StringParser.Parse<Vector2<TNumeric>>(parts[1], style, provider));
                if (parts.Length == 4)
                    return new AARectangle<TNumeric>(
                        StringParser.Parse<TNumeric>(parts[0], style, provider),
                        StringParser.Parse<TNumeric>(parts[1], style, provider),
                        StringParser.Parse<TNumeric>(parts[2], style, provider),
                        StringParser.Parse<TNumeric>(parts[2], style, provider));
                else throw new FormatException();
            }

            AARectangle<TNumeric> IBitConverter<AARectangle<TNumeric>>.Read(IReader<byte> stream)
            {
                return new AARectangle<TNumeric>(
                    BitConvert.Read<Vector2<TNumeric>>(stream),
                    BitConvert.Read<Vector2<TNumeric>>(stream));
            }

            void IBitConverter<AARectangle<TNumeric>>.Write(AARectangle<TNumeric> value, IWriter<byte> stream)
            {
                BitConvert.Write(stream, value.Origin);
                BitConvert.Write(stream, value.Dimensions);
            }
        }
    }

    public static class AARectangle
    {
        public static AARectangle<TNumeric> Between<TNumeric>(Vector2<TNumeric> point1, Vector2<TNumeric> point2) where TNumeric : struct, INumeric<TNumeric> => new AARectangle<TNumeric>(point1, point2 - point1);
        public static AARectangle<TNumeric> FromBottomCenter<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric> => new AARectangle<TNumeric>(GetTopCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<TNumeric> FromBottomLeft<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric> => new AARectangle<TNumeric>(bottomLeft, dimensions);
        public static AARectangle<TNumeric> FromBottomRight<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric> => new AARectangle<TNumeric>(GetTopLeft(bottomLeft, dimensions), dimensions);
        public static AARectangle<TNumeric> FromCenter<TNumeric>(Vector2<TNumeric> center, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric> => new AARectangle<TNumeric>(center, dimensions);
        public static AARectangle<TNumeric> FromLeftCenter<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric> => new AARectangle<TNumeric>(GetRightCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<TNumeric> FromRightCenter<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric> => new AARectangle<TNumeric>(GetLeftCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<TNumeric> FromTopCenter<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric> => new AARectangle<TNumeric>(GetBottomCenter(bottomLeft, dimensions), dimensions);
        public static AARectangle<TNumeric> FromTopLeft<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric> => new AARectangle<TNumeric>(GetBottomRight(bottomLeft, dimensions), dimensions);
        public static AARectangle<TNumeric> FromTopRight<TNumeric>(Vector2<TNumeric> bottomLeft, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric> => new AARectangle<TNumeric>(bottomLeft, dimensions);

        internal static Vector2<TNumeric> GetCenter<TNumeric>(Vector2<TNumeric> origin, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
             => origin + dimensions.Halved();

        internal static Vector2<TNumeric> GetBottomCenter<TNumeric>(Vector2<TNumeric> origin, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
            => new Vector2<TNumeric>(origin.X.Add(dimensions.X.Halved()), origin.Y);

        internal static Vector2<TNumeric> GetBottomRight<TNumeric>(Vector2<TNumeric> origin, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
            => new Vector2<TNumeric>(origin.X.Add(dimensions.X), origin.Y);

        internal static Vector2<TNumeric> GetLeftCenter<TNumeric>(Vector2<TNumeric> origin, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
            => new Vector2<TNumeric>(origin.X, origin.Y.Add(dimensions.Y.Halved()));

        internal static Vector2<TNumeric> GetRightCenter<TNumeric>(Vector2<TNumeric> origin, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
             => new Vector2<TNumeric>(origin.X.Add(dimensions.X), origin.Y.Add(dimensions.Y.Halved()));

        internal static Vector2<TNumeric> GetTopCenter<TNumeric>(Vector2<TNumeric> origin, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
             => new Vector2<TNumeric>(origin.X.Add(dimensions.X.Halved()), origin.Y.Add(dimensions.Y));

        internal static Vector2<TNumeric> GetTopLeft<TNumeric>(Vector2<TNumeric> origin, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
             => new Vector2<TNumeric>(origin.X, origin.Y.Add(dimensions.Y));

        internal static Vector2<TNumeric> GetTopRight<TNumeric>(Vector2<TNumeric> origin, Vector2<TNumeric> dimensions) where TNumeric : struct, INumeric<TNumeric>
             => origin + dimensions;
    }
}
