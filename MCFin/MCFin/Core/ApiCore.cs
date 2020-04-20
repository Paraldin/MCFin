﻿using MCFin.Constants;
using MCFin.Models;
using MCFin.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace MCFin.Core
{
    public static class ApiCore
    {
        public static async Task<List<Transaction>> GetAccountTransactions(int acctId)
        {
            string root = APIConstants.Root;
            string queryString = $"{root}/api/Accounts/GetAccountTransactions?acctId={acctId}";

            var jsonResult = await ApiServices.GetDataFromService(queryString).ConfigureAwait(false);

            if (jsonResult != null)
            {
                return JsonConvert.DeserializeObject<List<Transaction>>(jsonResult);
            }
            else
            {
                return null;
            }
        }
        public static async Task<List<PersonalAccount>> GetPersonalAccounts(int hhId = 0)
        {
            string root = APIConstants.Root;
            string queryString = $"{root}/api/Households/GetHouseholdAccounts?HHId={hhId}";

            var jsonResult = await ApiServices.GetDataFromService(queryString).ConfigureAwait(false);
            if (jsonResult != null)
            {
                return JsonConvert.DeserializeObject<List<PersonalAccount>>(jsonResult);
            }
            else
            {
                return null;
            }
        }

        public static async Task<List<Transaction>> GetHouseholdTransactions(int hhId, int month, int year)
        {
            string root = APIConstants.Root;
            string queryString = $"{root}/api/Households/GetHouseholdTransactions?hhId={hhId}&month={month}&year={year}";

            var jsonResult = await ApiServices.GetDataFromService(queryString).ConfigureAwait(false);

            if (jsonResult != null)
            {
                return JsonConvert.DeserializeObject<List<Transaction>>(jsonResult);
            }
            else
            {
                return null;
            }
        }
        public static async Task<List<Budget>> GetHouseholdBudgets(int hhId)
        {
            string root = APIConstants.Root;
            string queryString = $"{root}/api/Households/GetHouseholdBudgets?HHId={hhId}";

            var jsonResult = await ApiServices.GetDataFromService(queryString).ConfigureAwait(false);

            if (jsonResult != null)
            {
                return JsonConvert.DeserializeObject<List<Budget>>(jsonResult);
            }
            else
            {
                return null;
            }
        }
        public static async Task<Int16> ReconcileTransaction(int transId)
        {
            string root = APIConstants.Root;
            string queryString = $"{root}/api/Accounts/ReconcileTransaction?transId={transId}";

            var jsonResult = await ApiServices.GetDataFromService(queryString).ConfigureAwait(false);

            if (jsonResult != null)
            {
                return -1;
            }
            else
            {
                return 400;
            }
        }
        public static async Task<List<Transaction>> GetBudgetTransactions(int budgetId)
        {
            string root = APIConstants.Root;
            string queryString = $"{root}/api/Budgets/GetBudgetTransaction?budgetIdentity={budgetId}";

            var jsonResult = await ApiServices.GetDataFromService(queryString).ConfigureAwait(false);

            if (jsonResult != null)
            {
                return JsonConvert.DeserializeObject<List<Transaction>>(jsonResult);
            }
            else
            {
                return null;
            }
        }
        public static async Task<List<Category>> GetHouseholdCategories(int hhId)
        {
            string root = APIConstants.Root;
            string queryString = $"{root}/api/Households/GetHouseholdCategories?HHId={hhId}";

            var jsonResult = await ApiServices.GetDataFromService(queryString).ConfigureAwait(false);

            if (jsonResult != null)
            {
                return JsonConvert.DeserializeObject<List<Category>>(jsonResult);
            }
            else
            {
                return null;
            }
        }
        //Says post, but is a get
        public static async Task<Int16> PostTransaction(string description, DateTimeOffset date, decimal transactionAmount, bool type, int acctId, int categoryId, string enteredById, int budgetId = 0)
        {
            string root = APIConstants.Root;
            transactionAmount = type == true ? transactionAmount * -1 : transactionAmount;
            string queryString = $"{root}/api/Accounts/AddTransaction?description={description}&date={date}&transactionAmount={transactionAmount}&type={type}&acctId={acctId}&categoryId={categoryId}&enteredBy={enteredById}&budgetId={budgetId}";

            var jsonResult = await ApiServices.GetDataFromService(queryString).ConfigureAwait(false);

            if (jsonResult != null)
            {
                return -1;
            }
            else
            {
                return 500;
            }
        }
    }
}