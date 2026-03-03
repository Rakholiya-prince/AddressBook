using Address_Book.Models;

namespace Address_Book.Services
{
    public interface ICompanyService
    {
        Task<CompanyPageViewModel> GetCompanyPageViewModelAsync(int? id, string search);
        Task<CompanyPageViewModel> SaveCompanyAsync(CompanyPageViewModel model);
        Task DeleteCompanyAsync(int id);
    }
}
