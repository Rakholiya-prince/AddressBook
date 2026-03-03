using Address_Book.Models;
using Address_Book.Repositories;

namespace Address_Book.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IIndustryRepository _industryRepository;

        public CompanyService(ICompanyRepository companyRepository, IIndustryRepository industryRepository)
        {
            _companyRepository = companyRepository;
            _industryRepository = industryRepository;
        }

        public async Task<CompanyPageViewModel> GetCompanyPageViewModelAsync(int? id, string search)
        {
            var viewModel = new CompanyPageViewModel();

            viewModel.Industries = (await _industryRepository.GetAllIndustriesAsync()).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                viewModel.Companies = (await _companyRepository.SearchCompaniesAsync(search)).ToList();
            }
            else
            {
                viewModel.Companies = (await _companyRepository.GetAllCompaniesAsync()).ToList();
            }

            if (id.HasValue)
            {
                var company = await _companyRepository.GetCompanyByIdAsync(id.Value);
                viewModel.FormCompany = company ?? new Company();
            }

            return viewModel;
        }

        public async Task<CompanyPageViewModel> SaveCompanyAsync(CompanyPageViewModel model)
        {
            if (model.FormCompany.Company_ID == 0)
            {
                await _companyRepository.AddCompanyAsync(model.FormCompany);
            }
            else
            {
                await _companyRepository.UpdateCompanyAsync(model.FormCompany);
            }

            await _companyRepository.SaveChangesAsync();

            return model;
        }

        public async Task DeleteCompanyAsync(int id)
        {
            await _companyRepository.DeleteCompanyAsync(id);
            await _companyRepository.SaveChangesAsync();
        }
    }
}
