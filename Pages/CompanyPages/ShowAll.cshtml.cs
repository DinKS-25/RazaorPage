using Microsoft.AspNetCore.Mvc.RazorPages;
using JustCrud.Models;
using JustCrud.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace JustCrud.Pages.CompanyPages
{   
    [Authorize]
    public class ShowAll : PageModel
    {
        private readonly ILogger<ShowAll> _logger;
        private readonly ICallHandler _callHandler;
        public IEnumerable<Companies>? companies { get; set; }
        public ShowAll(ILogger<ShowAll> logger,ICallHandler callHandler)
        {
            _logger = logger;
            _callHandler=callHandler;
            // companies = new List<Companies>(){
            //     new Companies(){
            //         comapanyId=1,
            //         name="ABC",
            //         address="SomePlace",
            //         employeeCount=10
            //     },
            //     new Companies(){
            //         comapanyId=2,
            //         name="XYZ",
            //         address="SomeWhere",
            //         employeeCount=100
            //     },
            //     new Companies(){
            //         comapanyId=3,
            //         name="DEF",
            //         address="Hello",
            //         employeeCount=200
            //     },
            // };
        }
        public async Task OnGetAsync()
        {
            companies = await _callHandler.getCompanies();
        }
        public void OnPost(Companies company){
        }
    }
}