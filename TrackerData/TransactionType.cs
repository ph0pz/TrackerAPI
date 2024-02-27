using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrackerData;

public partial class TransactionType
{
    public int TransactionTypeId { get; set; }

    public string? TransactionTypeName { get; set; }

    [JsonIgnore]

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
