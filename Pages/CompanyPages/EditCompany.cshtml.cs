using JustCrud.Contracts;
using JustCrud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustCrud.Pages.CompanyPages
{
    [Authorize]
    public class EditCompany : PageModel
    {
        private readonly ILogger<EditCompany> _logger;

        [BindProperty]
        public Companies company { get; set; }
        private readonly ICallHandler _callHandler;

        public EditCompany(ILogger<EditCompany> logger, ICallHandler callHandler)
        {
            _callHandler = callHandler;
            _logger = logger;
        }

        public async Task OnGetAsync(string? id)
        {
            try
            {
                if (id != null)
                {
                    company = await _callHandler.getById(id);
                }
            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public async Task<IActionResult> OnPostAsync(){
            var res = await _callHandler.UpdateEmployee(company);
            if(res){
                return RedirectToPage("./ShowAll");
            }
            else 
            return Page();
        }
    }
}