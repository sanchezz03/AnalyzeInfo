using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MapToolSystem.BLL;
using MapToolSystem.Entities;

namespace WebApplicationMap.Pages
{
    public class AppRedirectPageModel : PageModel
    {
        private readonly App_InfoServices _appInfoServices;

        public AppRedirectPageModel(App_InfoServices appInfoServices)
        {
            _appInfoServices = appInfoServices;
        }

        public App_Info AppInfo { get; set; }

        public void OnGet(int id)
        {
            AppInfo = _appInfoServices.GetById(id);
        }
    }

}
