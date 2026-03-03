
namespace Address_Book.Models
{
    public class CompanyPageViewModel
    {
        public Company FormCompany { get; set; } = new Company();

        public List<Company> Companies { get; set; } = new List<Company>();

        public List<Industry> Industries { get; set; } = new List<Industry>();
    }
}
