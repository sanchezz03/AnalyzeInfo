using MapToolSystem.BLL;
using MapToolSystem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationMap.Helpers;

namespace WebApplicationMap.Pages
{
    [Authorize]
    public class RetiredServerPageModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Retired_Server_InfoServices _retiredServerInfoServices;
        [BindProperty]
        public Paginator<Retired_Server_Info> RetiredServerInfosList { get; set; }
        public RetiredServerPageModel(ILogger<IndexModel> logger, Retired_Server_InfoServices retiredServerInfoServices)
        {
            _logger = logger;
            _retiredServerInfoServices = retiredServerInfoServices;
        }
        public void OnGet(int?pageIndex)
        {
            int pageSize = 5;

            RetiredServerInfosList = Paginator<Retired_Server_Info>.Create(_retiredServerInfoServices.RetiredServerInfo_List(),
                 pageIndex ?? 1, pageSize);
        }
    }
}
