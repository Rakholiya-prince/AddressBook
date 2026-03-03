using Address_Book.Models;

namespace Address_Book.Repositories
{
    public interface IIndustryRepository
    {
        Task<IEnumerable<Industry>> GetAllIndustriesAsync();
    }
}
