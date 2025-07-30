using Jourlay.Domain.Entities.Common;
using Jourlay.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jourlay.Domain.Entities;

public class EmailAddressEntity : BaseEntity
{
    [Column("office_info_id")]
    public Guid OfficeInfoId { get; set; }

    [Column("email_address")]
    public string EmailAddress { get; set; } = string.Empty;

    [Column("email_type")]
    public EmailType Type { get; set; }

    [Column("is_primary")]
    public bool IsPrimary { get; set; } = false;

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("description")]
    public string? Description { get; set; }

    // Navigation property
    public virtual OfficeInfoEntity OfficeInfo { get; set; }
}
