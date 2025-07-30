namespace Jourlay.Application.Utilities.Extensions;

public static class CheckExtensions
{
    public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> value)
    {
        return value != null && value.Any();
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> value)
    {
        return value == null || !value.Any();
    }

    public static bool IsNotNull(this object objectToCheck)
    {
        return objectToCheck != null && !Convert.IsDBNull(objectToCheck);
    }

    public static bool IsNull(this object objectToCheck)
    {
        return objectToCheck == null || Convert.IsDBNull(objectToCheck);
    }

    public static bool IsInt64(this string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return false;

        return long.TryParse(value, out _);
    }
    public static bool IsDateTime(this string value)
    {
        if (string.IsNullOrWhiteSpace(value)) return false;

        return DateTime.TryParse(value, out _);
    }
}
