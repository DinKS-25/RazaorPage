using JustCrud.Contracts;
using JustCrud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustCrud.Pages.CompanyPages
{
    [Authorize]
    public class DeleteCompany : PageModel
    {
        private readonly ILogger<DeleteCompany> _logger;
        private readonly ICallHandler _callHandler;

        public Companies company { get; set; }

        public DeleteCompany(ILogger<DeleteCompany> logger, ICallHandler callHandler)
        {
            _callHandler = callHandler;
            _logger = logger;
        }

        public async Task OnGetAsync(string id)
        {
            if (id != null)
            {
                company = await _callHandler.getById(id);
            }
        }

        public async Task<IActionResult> OnPost(string id)
        {
            if (id != null)
            {
                var res = await _callHandler.deleteCompany(id);
                if (res)
                {
                    return RedirectToPage("./ShowAll");
                }
            }
            return Page();
        }
    }
}