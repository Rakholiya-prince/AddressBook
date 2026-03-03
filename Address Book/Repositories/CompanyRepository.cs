using Address_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Address_Book.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAllCompaniesAsync()
        {
            return await _context.Companies
                                 .Include(c => c.Industry)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Company>> SearchCompaniesAsync(string search)
        {
            return await _context.Companies
                                 .Include(c => c.Industry)
                                 .Where(c => c.Company_Name.Contains(search) ||
                                             c.ContactPerson.Contains(search))
                                 .ToListAsync();
        }

        public async Task<Company?> GetCompanyByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task AddCompanyAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
        }

        public async Task UpdateCompanyAsync(Company company)
        {
            _context.Companies.Update(company);
            await Task.CompletedTask;
        }

        public async Task DeleteCompanyAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
