using Address_Book.Models;
using Address_Book.Services;
using Microsoft.AspNetCore.Mvc;

namespace Address_Book.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IActionResult> Index(int? id, string search)
        {
            var viewModel = await _companyService.GetCompanyPageViewModelAsync(id, search);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(CompanyPageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // To display errors appropriately, we need industries and comparies fetched again
                var viewModel = await _companyService.GetCompanyPageViewModelAsync(null, null);
                model.Industries = viewModel.Industries;
                model.Companies = viewModel.Companies;
                return View("Index", model);
            }

            await _companyService.SaveCompanyAsync(model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteCompanyAsync(id);
            return RedirectToAction("Index");
        }
    }
}
