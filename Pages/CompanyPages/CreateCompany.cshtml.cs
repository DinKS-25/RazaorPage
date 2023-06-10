using JustCrud.Contracts;
using JustCrud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustCrud.Pages.CompanyPages
{
    [Authorize]
    public class CreateCompany : PageModel
    {
        private readonly ILogger<CreateCompany> _logger;



        [BindProperty]
        public Companies companies { get; set; }
        private readonly ICallHandler _callHandler;

        public CreateCompany(ILogger<CreateCompany> logger, ICallHandler callHandler)
        {
            _callHandler = callHandler;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var res = await _callHandler.createCompany(companies);
            if (res)
                return RedirectToPage("./ShowAll");

            return Page();
        }
    }
}