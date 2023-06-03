
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using MapToolSystem.BLL;
using MapToolSystem.Entities;
using WebApplicationMap.Helpers;
using System.Security.Claims;

namespace WebApplicationMap.Pages
{
    [Authorize]
    public class ServerInfoPageModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Server_InfoServices _serverInfoServices;

        public List<App_Info> AppInfos { get; set; }
        public ServerInfoPageModel(ILogger<IndexModel> logger, Server_InfoServices serverinfoservices)
        {
            _logger = logger;
            _serverInfoServices = serverinfoservices;
        }
        [TempData]
        public string FeedBackMessage { get; set; }

        [BindProperty(SupportsGet = true)]
        public int serverid { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searchValue { get; set; }

        [BindProperty(SupportsGet = true)]
        public string searcharg { get; set; }

        public string CurrentFilter { get; set; }
        public string FindValue { get; set; }
        public Server_Info serverInfoInfo { get; set; }

        [BindProperty]

        public List<Server_Info> ServerInfosList { get; set; }

        [BindProperty]
        public int selectServer { get; set; }


        [BindProperty]
        public Paginator<Server_Info> ServerInfoList { get; set; }

        [BindProperty]
        public User_Permition User_Permition { get; set; }
        public void OnGet(string currentFilter, string searchString, string findValue, int? pageIndex)
        {
            int pageSize = 5;
            if (searchValue == null)
                searchValue = findValue;

            if (searchString == null && currentFilter == null)
            {
                ServerInfoList = Paginator<Server_Info>.Create(_serverInfoServices.ServerInfo_List(),
                      pageIndex ?? 1, pageSize);
            }
            else
            {
                if (currentFilter == null)
                    SearchByValue(pageIndex, searchString);
                else
                    SearchByValue(pageIndex, currentFilter);
            }

            if(searchString == null)
                CurrentFilter = currentFilter;
            else
                CurrentFilter = searchString;
            FindValue = searchValue;

            if (serverid > 0)
            {
                serverInfoInfo = _serverInfoServices.ServerInfo_GetById(serverid);
                if (serverInfoInfo == null)
                {
                    FeedBackMessage = "Server id is not valid. No record fined.";
                }
                else
                {
                    FeedBackMessage = $"Server ID: {serverInfoInfo.Server_ID} Server Name: {serverInfoInfo.Server_Name}";
                }
            }
        }

        private void PopulateLists()
        {
            ServerInfosList = _serverInfoServices.ServerInfo_List();
        }
        //Generic falling post handler
        public void OnPost()

        {
            FeedBackMessage = "";
        }
   
        public void SearchByValue(int? pageNumber, string searcharg)
        {
            int pageSize = 4;

            if (!string.IsNullOrWhiteSpace(searcharg))
            {
                if (searchValue == "serverName")
                    ServerInfosList = _serverInfoServices.GetByPartialServerName(searcharg);
                else if (searchValue == "serialNumber")
                    ServerInfosList = _serverInfoServices.GetByPartialSerialNumber(searcharg);
                else if (searchValue == "serverLocation")
                    ServerInfosList = _serverInfoServices.GetByPartialServerLocation(searcharg);
                else if (searchValue == "maintanenceWindow")
                    ServerInfosList = _serverInfoServices.GetByPartialMaintanenceWindow(searcharg);
                else if (searchValue == "serviceOwner")
                    ServerInfosList = _serverInfoServices.GetByPartialServiceOwner(searcharg);
                else if (searchValue == "appInstanceName")
                    ServerInfosList = _serverInfoServices.GetByPartialAppInstanceName(searcharg);
                else if (searchValue == "dataCenter")
                    ServerInfosList = _serverInfoServices.GetByPartialDataCenter(searcharg);
                else if (searchValue == "ipAddress")
                    ServerInfosList = _serverInfoServices.GetByPartialIpAddress(searcharg);

                ServerInfoList = Paginator<Server_Info>.Create(ServerInfosList,
              pageNumber ?? 1, pageSize);
            }
            else if (serverid > 0)
            {
                ServerInfosList = new List<Server_Info> { _serverInfoServices.ServerInfo_GetById(serverid) };
            }
            else
            {
                FeedBackMessage = "Search elememnt or server ID is empty";
                ServerInfosList = null;
            }
        }
   
        public IActionResult OnPostSearch()
        {
            if (serverid < 1)
            {
                FeedBackMessage = "Required: Select a server to view";
            }
            return RedirectToPage(new { serverid = selectServer });

        }

        public IActionResult OnPostClear()
        {
            FeedBackMessage = "";
            ModelState.Clear();
            return RedirectToPage(new { serverid = (int?)null });
        }
    }
}

