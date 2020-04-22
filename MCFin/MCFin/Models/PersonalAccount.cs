using MCFin.Interfaces;
using MCFin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MCFin.Models
{
    public partial class PersonalAccount : BaseViewModel, IHasBalance
    {

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("HouseholdId")]
        public int HouseholdId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        private decimal _balance;
        [JsonProperty("Balance")]
        public decimal Balance { 
            get { return _balance; } 
            set 
            {
                SetProperty(ref _balance, value);
            } }

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

        public void UpdateBalance(decimal amount)
        {
            this.Balance -= amount;
        }
    }
}

