using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCFin.Models
{
    public partial class Budget
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("LastUpdate")]
        public DateTimeOffset LastUpdate { get; set; }

        [JsonProperty("Amount")]
        public decimal Amount { get; set; }

        [JsonProperty("HouseholdId")]
        public int HouseholdId { get; set; }

        [JsonProperty("CurrentBalance")]
        public decimal CurrentBalance { get; set; }
    }
}
