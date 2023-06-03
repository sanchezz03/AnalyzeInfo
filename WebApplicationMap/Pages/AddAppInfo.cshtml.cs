using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MapToolSystem.DAL;
using MapToolSystem.Entities;
using MapToolSystem.BLL;

namespace WebApplicationMap.Pages
{
    public class AddAppInfoModel : PageModel
    {
        private readonly MapToolContext dbContext;
        public User_Backlog_Info user_Backlog_Info { get; set; }
        public User_Backlog_InfoService _user_Backlog_InfoService { get; set; }
        public AddAppInfoModel(MapToolContext dbContext, User_Backlog_InfoService user_Backlog_InfoService)
        {
            this.dbContext = dbContext;
            this._user_Backlog_InfoService = user_Backlog_InfoService;
        }
        [BindProperty]
        public App_Info appInfo { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            App_InfoServices app_InfoServices = new App_InfoServices();
            App_Info appInfoModel = new App_Info();

            appInfoModel = app_InfoServices.MapRetired_App_Info(appInfo);
            if (appInfoModel.ServiceNow_AppNumber != null)
            {
                try
                {
                    dbContext.App_Infos.Add(appInfoModel);
                    user_Backlog_Info = _user_Backlog_InfoService.GetLastUserFromBacklog_List();
                    user_Backlog_Info.ActionDone = $"Add app info - {appInfoModel.Server_Name}";
                    dbContext.UserBacklogs.Add(user_Backlog_Info);
                    dbContext.SaveChanges();

                    ViewData["Message"] = "App Info created successfully!";
                }
                catch
                {
                    ViewData["Message"] = "All fields are required";
                }
            }
        }
    }
}
