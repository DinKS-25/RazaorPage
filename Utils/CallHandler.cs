using JustCrud.Contracts;
using JustCrud.Models;
using System.Dynamic;
using System.Net.Http.Headers;

namespace JustCrud.Utils
{
    public class CallHandler : ICallHandler
    {

        private string path = "https://crudcrud.com/api/d265b883ab734039b953dd6196586eee/companies";
        public async Task<IEnumerable<Companies>> getCompanies()
        {
            var companies = new List<Companies>();
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    companies = (List<Companies>)await response.Content.ReadAsAsync<IEnumerable<Companies>>();
                }
                return companies;
            }
        }

        public async Task<Companies> getById(string id)
        {
            Companies? company = null;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(path + "/" + id);
                if (response.IsSuccessStatusCode)
                {
                    company = await response.Content.ReadAsAsync<Companies>();
                }
                return company;
            }

        }

        public async Task<bool> createCompany(Companies company)
        {
            try
            {
                if (company != null)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        dynamic flexible = new ExpandoObject();
                        flexible.name = company.name;
                        flexible.address = company.address;
                        flexible.employeeCount = company.employeeCount;
                        var dictionary = (IDictionary<string, object>)flexible;
                        HttpResponseMessage response = await client.PostAsJsonAsync(path, dictionary);
                        response.EnsureSuccessStatusCode();
                        return response.IsSuccessStatusCode;
                    }
                }
                return false;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<bool> deleteCompany(string id)
        {
            try
            {
                if (id != null)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        HttpResponseMessage response = await client.DeleteAsync($"{path}/{id}");
                        response.EnsureSuccessStatusCode();
                        return response.IsSuccessStatusCode;
                    }
                }
                return false;
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public async Task<bool> UpdateEmployee(Companies company)
        {
            try
            {
                if (company != null)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        // dynamic flexible = new ExpandoObject();
                        // flexible.name = company.name;
                        // flexible.address = company.address;
                        // flexible.employeeCount = company.employeeCount;
                        // var dictionary = (IDictionary<string, object>)flexible;
                        HttpResponseMessage response = await client.PutAsJsonAsync($"{path}/{company._id}", company);
                        response.EnsureSuccessStatusCode();
                        return response.IsSuccessStatusCode;
                    }
                }
                else
                    return false;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}