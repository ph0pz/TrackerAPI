using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrackerData;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? TransactionTypeId { get; set; }

    public int? CategoryTypeId { get; set; }

    public double? Amount { get; set; }

    public DateTime? CreateAt { get; set; }

    public int? UserId { get; set; }

    public int? Day { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }

    public int? CategoryId { get; set; }
    //[JsonIgnore]
    public virtual CategoryType? CategoryType { get; set; }
    //[JsonIgnore]

    public virtual TransactionType? TransactionType { get; set; }
    [JsonIgnore]

    public virtual Person? User { get; set; }

    //[JsonIgnore]
    public virtual Category? Category { get; set; }

    public string? Name { get; set; }
}
