using Jourlay.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jourlay.Domain.Entities;

public class ContactUsEntity : AggregateRoot
{
    public virtual ICollection<OfficeInfoEntity> Offices { get; set; } = new List<OfficeInfoEntity>();

    [Column("facebook_link")]
    public string FacebookLink { get; set; } = string.Empty;

    [Column("instagram_link")]
    public string InstagramLink { get; set; } = string.Empty;

    [Column("youtube_link")]
    public string YouTubeLink { get; set; } = string.Empty;

    [Column("twitter_link")]
    public string TwitterLink { get; set; } = string.Empty;

}
