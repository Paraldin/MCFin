using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCFin.Models
{
    public partial class Transaction
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Amount")]
        public decimal Amount { get; set; }

        [JsonProperty("Reconciled")]
        public bool Reconciled { get; set; }

        [JsonProperty("Date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("IsDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("CatName")]
        public string CatName { get; set; }

        [JsonProperty("BudgetName")]
        public string BudgetName { get; set; }

        [JsonProperty("BudgetId")]
        public int? BudgetId { get; set; }

        [JsonProperty("AccountName")]
        public string AccountName { get; set; }
    }

    public partial class PostTransaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal Amount { get; set; }
        public bool Type { get; set; }
        public bool Void { get; set; }
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public int BudgetItemId { get; set; }
        public string EnteredById { get; set; }
        public bool Reconciled { get; set; }
        public decimal ReconciledAmount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
