using MCFin.Interfaces;
using MCFin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCFin.Models
{
    public partial class Budget : BaseViewModel, IHasBalance
    {
        private decimal _balance;
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
        
        [JsonProperty("IsDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("CurrentBalance")]
        public decimal CurrentBalance {
            get { return _balance; }
            set
            {
                SetProperty(ref _balance, value);
            }
        }

        public void UpdateBalance(decimal amount)
        {
            this.CurrentBalance -= amount;
        }
    }
}
