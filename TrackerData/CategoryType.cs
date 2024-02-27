using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TrackerData;

public partial class CategoryType
{
    public int CategoryTypeId { get; set; }

    public string? CategoryTypeName { get; set; }



    [JsonIgnore]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
