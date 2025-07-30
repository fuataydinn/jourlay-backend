using Jourlay.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jourlay.Domain.Entities;

public class OfficeInfoEntity : AggregateRoot
{
    [Column("contact_us_id")]
    public Guid ContactUsId { get; set; }

    [Column("opening_hours_weekday")]
    public string OpeningHoursWeekday { get; set; } = string.Empty;

    [Column("opening_hours_weekend")]
    public string OpeningHoursWeekend { get; set; } = string.Empty;

    // Navigation properties
    public virtual ContactUsEntity ContactUs { get; set; }
    public virtual ICollection<PhoneNumberEntity> PhoneNumbers { get; set; } = new List<PhoneNumberEntity>();
    public virtual ICollection<EmailAddressEntity> EmailAddresses { get; set; } = new List<EmailAddressEntity>();
}
