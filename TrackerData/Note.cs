using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrackerData;

public partial class Note
{
    public int NoteId { get; set; }

    public int? UserId { get; set; }

    public string? Detail { get; set; }

    public DateTime? CreateAt { get; set; }
    [JsonIgnore]
    public virtual Person? User { get; set; }
}
