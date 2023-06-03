using Microsoft.AspNetCore.Mvc.RazorPages;
using MapToolSystem.BLL;
using MapToolSystem.Entities;
using WebApplicationMap.Helpers;

namespace WebApplicationMap.Pages
{
    public class RetiredServerRedirectPageModel : PageModel
    {
        private readonly Retired_Server_InfoServices _retiredServerInfoServices;

        public RetiredServerRedirectPageModel(Retired_Server_InfoServices retiredServerInfoServices)
        {
            _retiredServerInfoServices = retiredServerInfoServices;
        }


        public List<Retired_Server_Info> RetiredServerInfoList { get; set; }
        public Retired_Server_Info RetiredServerInfo { get; set; }

        public void OnGet(int id)
        {
            RetiredServerInfo = _retiredServerInfoServices.RetiredServerInfoGetById(id);
        }
    }

}
