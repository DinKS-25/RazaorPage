using JustCrud.Models;
namespace JustCrud.Contracts
{
    public interface ICallHandler
    {
        public Task<IEnumerable<Companies>> getCompanies();
        public Task<Companies> getById(string id);
        public Task<bool> createCompany(Companies company);
        public Task<bool> deleteCompany(string id);
        public Task<bool> UpdateEmployee(Companies company);
    }
}