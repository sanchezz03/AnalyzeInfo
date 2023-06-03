using Microsoft.AspNetCore.Mvc.RazorPages;
using MapToolSystem.BLL;
using MapToolSystem.Entities;

namespace WebApplicationMap.Pages
{
    public class ServerRedirectPageModel : PageModel
    {
        private readonly Server_InfoServices _serverInfoServices;

        public ServerRedirectPageModel(Server_InfoServices serverInfoServices)
        {
            _serverInfoServices = serverInfoServices;
        }

        public Server_Info ServerInfo { get; set; }

        public void OnGet(int id)
        {
            ServerInfo = _serverInfoServices.ServerInfo_GetById(id);
        }
    }

}
