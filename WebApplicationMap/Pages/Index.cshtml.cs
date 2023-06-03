using MapToolSystem.BLL;
using MapToolSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using WebApplicationMap.Helpers;

namespace WebApplicationMap.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly App_InfoServices _appInfoServices;
        private readonly Server_InfoServices _serverInfoServices;
        // Remove this line
        // private string? searcharg;

        public string FeedBack { get; private set; }
        [BindProperty(SupportsGet = true)]
        public string searcharg { get; set; }
        [BindProperty(SupportsGet = true)]
        public string searchValue { get; set; }
        public string CurrentFilter { get; set; }
        public string FindValue { get; set; }
        public List<App_Info> AppInfos { get; set; } = new List<App_Info>();
        public List<Server_Info> ServerInfos { get; set; } = new List<Server_Info>();

        [BindProperty]
        public Paginator<Server_Info> ServerInfoList { get; set; }
        [BindProperty]
        public Paginator<App_Info> AppInfo { get; set; } = new();
        public IndexModel(ILogger<IndexModel> logger, App_InfoServices appinfoservices, Server_InfoServices serverinfoservices)
        {
            _logger = logger;
            _appInfoServices = appinfoservices;
            _serverInfoServices = serverinfoservices;
        }

        [TempData]


        [BindProperty(SupportsGet = true)]

        public int serverId { get; set; }


        public IActionResult OnPost()
        {
            // Redirect to the AppRedirectPage with the selected app ID
            return RedirectToPage("/AppRedirectPage", new { id = Request.Form["appId"] });
        }

        public void OnGet(string currentFilter, string searchString, string findValue, int? pageIndexForServer, int? pageIndexForApp)
        {
            int pageSize = 5;

            if (searchValue == null)
                searchValue = findValue;

            if (searchString == null && currentFilter == null)
            {
                AppInfo = Paginator<App_Info>.Create(_appInfoServices.GetAppInfo(),
               pageIndexForApp ?? 1, pageSize);

                ServerInfoList = Paginator<Server_Info>.Create(_serverInfoServices.ServerInfo_List(),
                          pageIndexForServer ?? 1, pageSize);

            }
            else
            {
                if (currentFilter == null)
                    SearchByValue(pageIndexForServer, pageIndexForApp, searchString);
                else
                    SearchByValue(pageIndexForServer, pageIndexForApp, currentFilter);
            }

            if (searchString == null)
                CurrentFilter = currentFilter;
            else
                CurrentFilter = searchString;
            FindValue = searchValue;
            //AppInfos = _appInfoServices.GetAppInfo();

            //ServerInfos = _serverInfoServices.ServerInfo_List();
        }

        public IActionResult OnPostServer()
        {
            // Redirect to the ServerRedirectPage with the selected server ID
            return RedirectToPage("/ServerRedirectPage", new { id = Request.Form["serverId"] });
        }

        public void OnGetServer()
        {
            ServerInfos = _serverInfoServices.ServerInfo_List();
        }
        public void SearchByValue(int? pageNumberForServer, int? pageNumberForApp, string searcharg)
        {
            int pageSize = 10;
            if (!string.IsNullOrWhiteSpace(searcharg))
            {
                /* AppInfos = _appInfoServices.GetByPartialValue(searcharg);*/
                if (searchValue == "primaryServiceOwner")
                    AppInfos = _appInfoServices.GetByPartialPrimaryServiceOwner(searcharg);
                else if (searchValue == "instanceName")
                    AppInfos = _appInfoServices.GetByPartialInstanceName(searcharg);
                else if (searchValue == "appName")
                    AppInfos = _appInfoServices.GetByPartialAppName(searcharg);
                else if (searchValue == "appVersion")
                    AppInfos = _appInfoServices.GetByPartialAppVersion(searcharg);
                else if (searchValue == "adIntegrated")
                    AppInfos = _appInfoServices.GetByPartialAdIntegrated(searcharg);
                else if (searchValue == "citrixHosted")
                    AppInfos = _appInfoServices.GetByPartialCitrixHosted(searcharg);

                AppInfo = Paginator<App_Info>.Create(AppInfos,
              pageNumberForApp ?? 1, pageSize);
            }

            if (!string.IsNullOrWhiteSpace(searcharg))
            {
                if (searchValue == "serverName")
                    ServerInfos = _serverInfoServices.GetByPartialServerName(searcharg);
                else if (searchValue == "serialNumber")
                    ServerInfos = _serverInfoServices.GetByPartialSerialNumber(searcharg);
                else if (searchValue == "serverLocation")
                    ServerInfos = _serverInfoServices.GetByPartialServerLocation(searcharg);
                else if (searchValue == "maintanenceWindow")
                    ServerInfos = _serverInfoServices.GetByPartialMaintanenceWindow(searcharg);
                else if (searchValue == "dataCenter")
                    ServerInfos = _serverInfoServices.GetByPartialDataCenter(searcharg);
                else if (searchValue == "ipAddress")
                    ServerInfos = _serverInfoServices.GetByPartialIpAddress(searcharg);

                ServerInfoList = Paginator<Server_Info>.Create(ServerInfos,
              pageNumberForServer ?? 1, pageSize);
            }

            
        }
        public IActionResult OnPostClear()
        {
            ModelState.Clear();
            return RedirectToPage(new { serverid = (int?)null });
        }
        public List<App_Info> GetAppInfo()
        {
            return _appInfoServices.GetAppInfo();
        }
        public App_Info GetById(int id)
        {
            return _appInfoServices.GetById(id);
        }

    }
}
