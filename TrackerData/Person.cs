using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrackerData;

public partial class Person
{
    public int UserId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? NickName { get; set; }

    public int? Age { get; set; }
    [JsonIgnore]

    public virtual ICollection<Note> Notes { get; set; } = new List<Note>();
    [JsonIgnore]

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
