using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MapToolSystem.BLL;
using MapToolSystem.DAL;
using MapToolSystem.Entities;
using WebApplicationMap.Helpers;

namespace WebApplicationMap.Pages
{
    [Authorize]
    public class AppInfoPageModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly App_InfoServices _appInfoServices;
        private readonly Server_InfoServices _serverInfoServices;

        public AppInfoPageModel(ILogger<IndexModel> logger,
                                              App_InfoServices appInfoServices, Server_InfoServices serverInfoServices)
        {
            _logger = logger;
            _appInfoServices = appInfoServices;
            _serverInfoServices = serverInfoServices;
        }


        [TempData]

        public string FeedBack { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searcharg { get; set; }
        public Paginator<App_Info> AppInfos { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public string searchValue { get; set; }
        public string CurrentFilter { get; set; }
        public string FindValue { get; set; }
        public List<App_Info> AppInfo { get; set; }
        public void OnGet(string currentFilter, string searchString, int? pageIndex)
        {
            int pageSize = 4;

            if (searchString == null && currentFilter == null)
            {
                AppInfos = Paginator<App_Info>.Create(_appInfoServices.GetAppInfo(),
                pageIndex ?? 1, pageSize);
            }
            else
            {
                if (currentFilter == null)
                    SearchByValue(pageIndex, searchString);
                else
                    SearchByValue(pageIndex, currentFilter);
            }

            if (searchString == null)
                CurrentFilter = currentFilter;
            else
                CurrentFilter = searchString;
        }
        public void SearchByValue(int? pageNumber, string searcharg)
        {
            int pageSize = 4;

            if (!string.IsNullOrWhiteSpace(searcharg))
            {
                AppInfo = _appInfoServices.GetByPartialValue(searcharg);

                AppInfos = Paginator<App_Info>.Create(AppInfo,
              pageNumber ?? 1, pageSize);
            }
            else
            {
                AppInfos = (Paginator<App_Info>)_appInfoServices.GetByPartialInstanceName(searcharg);
            }
            //   AppInfo = _appInfoServices.GetByPartialValue(searcharg);
            //  if (!string.IsNullOrWhiteSpace(searcharg))
            //  {
            //      if (searchValue == "serverName")
            //          AppInfo = _appInfoServices.GetByPartialAppId(Convert.ToInt32(searcharg));
            //      else if (searchValue == "primaryServiceOwner")
            //          AppInfo = _appInfoServices.GetByPartialPrimaryServiceOwner(searcharg);
            //      else if (searchValue == "appVersion")
            //          AppInfo = _appInfoServices.GetByPartialAppVersion(searcharg);
            //      else if (searchValue == "instanceName")
            //          AppInfo = _appInfoServices.GetByPartialInstanceName(searcharg);
            //      else if (searchValue == "adIntegrated")
            //          AppInfo = _appInfoServices.GetByPartialAdIntegrated(searcharg);
            //      else if (searchValue == "citrixHosted")
            //          AppInfo = _appInfoServices.GetByPartialCitrixHosted(searcharg);
            //      else if (searchValue == "hyperDriveReady")
            //          AppInfo = _appInfoServices.GetByPartialHyperDriveReady(searcharg);
            //      else if (searchValue == "issRequired")
            //          AppInfo = _appInfoServices.GetByPartialIssRequired(searcharg);
            //      else if (searchValue == "dotNet")
            //          AppInfo = _appInfoServices.GetByPartialDotNet(searcharg);
            //      else if (searchValue == "sslCertificate")
            //          AppInfo = _appInfoServices.GetByPartialSslCertificate(searcharg);
            //      else if (searchValue == "avExclusions")
            //          AppInfo = _appInfoServices.GetByPartialAvExclusions(searcharg);
            //      else if (searchValue == "appStorage")
            //          AppInfo = _appInfoServices.GetByPartialAppStorage(searcharg);
            //      else if (searchValue == "iamIntegrated")
            //          AppInfo = _appInfoServices.GetByPartialIAmIntegrated(searcharg);


            //      AppInfos = Paginator<App_Info>.Create(AppInfo,
            //pageNumber ?? 1, pageSize);

            //  }
        }
        

        public IActionResult OnPostClear()
        {
            FeedBack = "";
            ModelState.Clear();
            return RedirectToPage(new { searcharg = (string?)null });
        }
    }
}

