Jodo.Extensions
===============
[![Test](https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/tests.yml/badge.svg)](https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/tests.yml) [![CodeQL](https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/JosephJShort/Jodo.Extensions/actions/workflows/codeql-analysis.yml)

> Documentation in draft

A collection of useful C# libraries written in the style of the .NET SDK.

CheckedNumerics
---------------
Provides a variety of numeric value types with built-in protection from overflow. For use in systems where it is important not to have unexpected negative, infinite or NaN values. Usage is identical to primitive value types, but with different results in cases of overflow and division by zero.

> Note: Checked arithmetic takes additional processor time, and wrapper structs employed by CheckedNumerics increase memory usage compared to primitive types alone. If you wish to use CheckedNumerics in a performance critical application, please consider profiling to assess the impact on performance. As a rule of thumb, the impact is acceptable in business, game, or simulation applications, but not in number crunching or big-data applications.

The following value types are provided:
| CheckedNumerics value type | Underlying CLR type | Behaviour |
| - | - | - |
| cint | int | Uses a `checked` context to perform arithmetic. Operations that would overflow do NOT throw a `System.OverflowException`, but return `cint.MinValue` or `cint.MaxValue`. Division by zero does NOT throw a `System.DivideByZeroException`, but returns `cint.MaxValue`. |
| ucint | uint | _Same as `cint`._ |
| cfloat | float | Operations that would overflow do NOT return `PositiveInfinity` or `NegativeInfinity` but instead return `cfloat.MaxValue` or `float.MinValue` repectively. Division by zero does NOT return `PositiveInfinity`, `NegativeInfinity` or `NaN`, but returns `cfloat.MaxValue`. (It is not possible for a `cfloat` to be infinite or `NaN`.) |
| cdouble | double | _As above_ |
| fix64 | long | A signed fixed-point number with a 40 bit integral part and a 24 bit mantissa. |
| ufix64 | long | A unsigned fixed-point number with a 40 bit integral part and a 24 bit mantissa. |

The following features are provided:
| Feature | Notes |
| - | - |
| Operators `==`, `!=`, `>`, `>=`, `<`, `<=`, `+`, `++`, `-`, `*`, `/`, `%`  | All CheckedNumerics value types implement custom operators, allowing for easy use in expressions. Additionally, All CheckedNumerics value types have implicit conversions from built-in numeric types, allowing them to be used in expressions with literals. CheckedNumerics value types based on integral primitives have custom `&`, `|`, `^`, `~`, `<<` and `>>` operators. |
| `INumeric<T>` | All CheckedNumerics value types implement `INumeric<T>`, allowing for the creation generic numerical systems. Additionally, the `INumeric<T>` interface provides overloads for arithmetic and comparison operators, allowing for limited expressions in a generic context (unfortunately, equality and conversion operators are not supported on interfaces). |
| `Math<T>` | The static class, `Math<T>`, provides equivalent functions to `System.Math` (e.g. `Log(T)`, `Pow(T)`, `Sqrt(T)`) for all types that implement `INumeric<T>`. |
| `BitConverter<T>` | The static class ,`BitConverter<T>`, similar to `System.BitConverter`, provides conversion to and from `ReadOnlySpan<byte>` for all types that implement `INumeric<T>`. |
| `StringFormatter<T>` | The static class `StringFormatter<T>` provides string parsing and formatting for all types that implement `INumeric<T>`. In addition, all CheckedNumerics value types implement `System.IFormattable` and can be used with standard format strings (e.g. `N2`). |
| `System.Random.NextNumeric<T>` | An extension method on `System.Random` that provides randomly generated values for all types that implement `INumeric<T>`. Values can be generated between two bounds or without bounds. |
| `[Serializable]` | All numeric types implement `System.ISerializable`, have the `SerializableAttribute` and a deserialization constructor. |
| `float Approximate(float offset)` | All types that implement `INumeric<T>` can be easily converted to floats for use in graphical applications. |
| _Other_ | All CheckedNumerics value types implement `System.IEquatable<T>`, `System.IComparable<T>` and `System.IComparable`, override `EqualTo(object)`, `GetHashCode()` and `ToString()` and have a `[DebuggerDisplay]` attribute. |

CheckedGeometry
---------------
Provides geometric value types that make use of generic maths from CheckedNumerics.

| CheckedGeometry type | Notes |
| AARectangle<T> | Axis aligned rectangle |
| Rectangle<T> |  |
| Circle<T> |  |
| Angle<T> |  |
| Unit<T> |  |
| Vector2<T> |  |
| Vector3<T> |  |

Collections
-----------
