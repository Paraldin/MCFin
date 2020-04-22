using MCFin.Constants;
using MCFin.Models;
using MCFin.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static MCFin.Models.PersonalAccount;

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
                List<PersonalAccount> personalAccounts = JsonConvert.DeserializeObject<List<PersonalAccount>>(jsonResult);
                return personalAccounts;
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
                List<Transaction> ts = JsonConvert.DeserializeObject<List<Transaction>>(jsonResult);
                return ts;
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
                List<Budget> bs = JsonConvert.DeserializeObject<List<Budget>>(jsonResult);
                return bs;
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
        //Says post, but is a get
        public static async Task<Int16> PostAccount(PostAccount a)
        {
            string root = APIConstants.Root;
            string queryString = $"{root}/api/Accounts/AddAccount?HHid={a.HHid}&accountName={a.AccountName}&accountBalance={a.AccountBalance}&createdById={a.CreatedById}&warning={a.Warning}";

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
        //Says post, but is a get
        public static async Task<Int16> PostBudget(Budget b)
        {
            string root = APIConstants.Root;
            string queryString = $"{root}/api/Budgets/AddBudget?HHid={b.HouseholdId}&budgetAmount={b.Amount}&budgetName={b.Name}";

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
        //Says post, but is a get
        public static async Task<Int16> PostCategory(int hhId, string name)
        {
            string root = APIConstants.Root;
            string queryString = $"{root}/api/Households/AddCategory?HHid={hhId}&name={name}";

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
        public static async Task DeleteTransaction(int transId)
        {
            string root = APIConstants.Root;
            string queryString = $"{root}/api/Accounts/DeleteTransaction?transId={transId}";

            var jsonResult = await ApiServices.GetDataFromService(queryString).ConfigureAwait(false);
        }
        public static async Task<AuthenticatedUser> Authenticate(string username, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
            });

            using (HttpResponseMessage response = await APIConstants.Client.PostAsync("/Token", data))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
