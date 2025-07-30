using Jourlay.Domain.Enums.Errors;

namespace Jourlay.Application.Utilities.Errors.Base;

public readonly record struct Error(string Message, ErrorType ErrorType = ErrorType.WARNING)
{
    public static readonly Error Empty = new("Error is empty.", ErrorType.ERROR);
    public static readonly Error NotFound = new("Kayıt bulunamadı.", ErrorType.ERROR);
    public static readonly Error NotFoundByQuery = new("Aradiginiz kriterlere uygun kayit bulunamadi.", ErrorType.WARNING);
    public static readonly Error SystemError = new("Sistem tarafinda beklenmeyen bir hata olustu. Lutfen yetkili ile iletisime geciniz.", ErrorType.ERROR);
    public static Error CreateError(string? message = null) => string.IsNullOrWhiteSpace(message) ? NotFound : new(message, ErrorType.ERROR);
}
