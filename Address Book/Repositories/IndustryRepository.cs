using Address_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Address_Book.Repositories
{
    public class IndustryRepository : IIndustryRepository
    {
        private readonly AppDbContext _context;

        public IndustryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Industry>> GetAllIndustriesAsync()
        {
            return await _context.Industries.ToListAsync();
        }
    }
}
