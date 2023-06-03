using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MapToolSystem.DAL;
using MapToolSystem.Entities;
using MapToolSystem.BLL;

namespace WebApplicationMap.Pages
{
    public class AddServerInfoModel : PageModel
    {
        private readonly MapToolContext dbContext;
        public User_Backlog_Info user_Backlog_Info { get; set; }
        public User_Backlog_InfoService _user_Backlog_InfoService { get; set; }
        public AddServerInfoModel(MapToolContext dbContext,User_Backlog_InfoService user_Backlog_InfoService)
        {
            this.dbContext = dbContext;
            this._user_Backlog_InfoService = user_Backlog_InfoService;
        }

        [BindProperty]
        public Server_Info serverInfo { get; set; }
        public void OnGet()
        {

        }

        public void OnPost()
        {
            Server_InfoServices server_InfoServices = new Server_InfoServices();
            Server_Info serviceInfoModel = new Server_Info();

            serviceInfoModel = server_InfoServices.MapRetired_Server_Info(serverInfo);
            if (serviceInfoModel.NoOfCPUs != null)
            {
                try
                {

                    dbContext.Server_Infos.Add(serviceInfoModel);
                    user_Backlog_Info = _user_Backlog_InfoService.GetLastUserFromBacklog_List();
                    user_Backlog_Info.ActionDone = $"Add server info - {serviceInfoModel.Server_Name}";
                    dbContext.UserBacklogs.Add(user_Backlog_Info);
                    dbContext.SaveChanges();

                    ViewData["Message"] = "Server Info created successfully!";
                }
                catch
                {
                    ViewData["Message"] = "All fields are required";
                }
            }
        }
    }
}
