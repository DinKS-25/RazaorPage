using JustCrud.Contracts;
using JustCrud.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JustCrud.Pages.CompanyPages
{
    [Authorize]
    public class ViewCompany : PageModel
    {
        private readonly ILogger<ViewCompany> _logger;
        private readonly ICallHandler _callHandler;

        public Companies company { get; set; }

        public ViewCompany(ILogger<ViewCompany> logger,ICallHandler callHandler)
        {
            _logger = logger;
            _callHandler = callHandler;
        }

        public async Task OnGetAsync(string id)
        {
            var temp = ViewData["name"];
            if(id!=null){
                
                company = await _callHandler.getById(id);

            }
        }
    }
}