# Vogen Quick Reference

Project version: **Vogen 8.0.5**

Docs: https://stevedunn.github.io/Vogen/overview.html

## Creating a Value Object — Checklist

1. **Pick the underlying primitive** (`int`, `string`, `decimal`, `Guid`, etc.)
2. **Choose struct vs class**
   - `readonly partial struct` — preferred for small value types (less allocation, true immutability)
   - `partial class` — better for EF Core primary keys (EF checks for null to determine auto-generation)
3. **Add the attribute**: `[ValueObject<T>]`
4. **Add validation** (optional): `private static Validation Validate(in T value)` method
5. **Add normalization** (optional): `private static T NormalizeInput(T input)` — runs *before* Validate (e.g., trimming strings)
6. **Configure attribute parameters** as needed (see below)

### Minimal Example

```csharp
[ValueObject<int>]
public readonly partial struct ProgramId { }
```

### With Validation

```csharp
[ValueObject<string>]
public readonly partial struct ProgramName
{
  public const int MaxLength = 255;

  private static Validation Validate(in string name)
  {
    if (string.IsNullOrEmpty(name))
      return Validation.Invalid("Name cannot be empty");

    if (name.Length > MaxLength)
      return Validation.Invalid($"Name cannot exceed {MaxLength} characters");

    return Validation.Ok;
  }
}
```

### With Normalization

```csharp
[ValueObject<string>]
public readonly partial struct EmailAddress
{
  private static string NormalizeInput(string input) => input.Trim().ToLowerInvariant();

  private static Validation Validate(in string value)
  {
    if (string.IsNullOrEmpty(value))
      return Validation.Invalid("Email cannot be empty");
    return Validation.Ok;
  }
}
```

## What Vogen Generates For You

- `From(T value)` — factory method (the only way to create instances)
- `TryFrom(T value)` — non-throwing factory method
- `Value` property — access the underlying primitive
- `IEquatable<T>`, `IComparable<T>`, `GetHashCode()`, `ToString()`
- Equality operators (`==`, `!=`)
- Explicit cast operators (to/from primitive)
- Serialization converters (based on `conversions` parameter)

The Roslyn analyzer **prevents** `new`, `default`, and `Activator.CreateInstance` at compile time.

## `[ValueObject<T>]` Parameters

| Parameter | Default | Purpose |
|---|---|---|
| `conversions` | `Conversions.Default` | Serializers/converters to generate |
| `throws` | `ValueObjectValidationException` | Exception type on validation failure |
| `comparison` | `ComparisonGeneration.UseUnderlying` | Whether `IComparable` is generated |
| `toPrimitiveCasting` | `CastOperator.Explicit` | Cast from VO to primitive |
| `fromPrimitiveCasting` | `CastOperator.Explicit` | Cast from primitive to VO |
| `customizations` | `Customizations.None` | Feature flags |
| `deserializationStrictness` | `AllowValidAndKnownInstances` | How strict deserialization is |
| `debuggerAttributes` | `DebuggerAttributeGeneration.Full` | Debugger display level |
| `stringComparers` | `StringComparersGeneration.Omit` | String comparison generation |
| `parsableForStrings` | `GenerateMethodsAndInterface` | `IParsable` for strings |
| `parsableForPrimitives` | `HoistMethodsAndInterfaces` | `Parse`/`TryParse` for primitives |
| `primitiveEqualityGeneration` | `GenerateOperatorsAndMethods` | Allow `vo == 123` comparisons |

## Conversions (Flags Enum)

Combine with `|` for multiple: `Conversions.SystemTextJson | Conversions.EfCoreValueConverter`

| Value | What it generates |
|---|---|
| `Default` | TypeConverter + SystemTextJson |
| `None` | Nothing |
| `TypeConverter` | System.ComponentModel TypeConverter |
| `SystemTextJson` | STJ JsonConverter |
| `NewtonsoftJson` | Newtonsoft JsonConverter |
| `EfCoreValueConverter` | EF Core ValueConverter |
| `DapperTypeHandler` | Dapper type handler |
| `LinqToDbValueConverter` | LINQ to DB converter |

## Assembly-Wide Defaults

Set once per assembly to avoid repeating parameters on every VO:

```csharp
[assembly: VogenDefaults(
  staticAbstractsGeneration: StaticAbstractsGeneration.MostCommon
    | StaticAbstractsGeneration.InstanceMethodsAndProperties)]
```

This generates the `IVogen<TSelf, TPrimitive>` interface, enabling generic constraints like:
```csharp
where TId : IVogen<TId, int>
```

## Pre-defined / Special Instances

Inside the VO type, `new` is allowed for defining known instances that bypass validation:

```csharp
[ValueObject<int>]
public readonly partial struct Age
{
  public static readonly Age Unspecified = new(-1);
}
```

## EF Core Integration

Two approaches:

1. **Per-VO**: Add `Conversions.EfCoreValueConverter`, then use `.HasVogenConversion()` in `OnModelCreating`
2. **Marker class** (keeps domain clean of infrastructure): Use `[EfCoreConverter<T>]` attributes and call `RegisterAllIn...()` in `ConfigureConventions`
