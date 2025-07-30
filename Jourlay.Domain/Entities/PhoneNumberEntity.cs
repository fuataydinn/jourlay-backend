using Jourlay.Domain.Entities.Common;
using Jourlay.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jourlay.Domain.Entities;

public class PhoneNumberEntity : BaseEntity
{
    [Column("office_info_id")]
    public Guid OfficeInfoId { get; set; } // Foreign Key

    [Column("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Column("phone_type")]
    public PhoneType Type { get; set; } // Enum: Mobile, Landline, Fax, WhatsApp

    [Column("country_code")]
    public string CountryCode { get; set; } = string.Empty;

    [Column("is_primary")]
    public bool IsPrimary { get; set; } = false;

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("description")]
    public string? Description { get; set; } // "Ana Hat", "Rezervasyon", "Acil Durum" etc.

    // Navigation property
    public virtual OfficeInfoEntity OfficeInfo { get; set; }
}
