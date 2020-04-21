using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCFin.Models
{
    public partial class PersonalAccount
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("HouseholdId")]
        public int HouseholdId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Balance")]
        public decimal Balance { get; set; }

        [JsonProperty("ReconciledBalance")]
        public decimal ReconciledBalance { get; set; }

        [JsonProperty("WarningAmount")]
        public decimal WarningAmount { get; set; }

        [JsonProperty("CreatedById")]
        public Guid CreatedById { get; set; }

        [JsonProperty("IsDeleted")]
        public bool IsDeleted { get; set; }
        public PersonalAccount()
        {
            Name = " ";
            Balance = 0;
            ReconciledBalance = 0;
            WarningAmount = 0;
        }

       public class PostAccount
        {
            public int HHid { get; set; }
            public string AccountName { get; set; }
            public decimal AccountBalance { get; set; }
            public string CreatedById { get; set; }
            public decimal Warning { get; set; }
        }
    }
}

