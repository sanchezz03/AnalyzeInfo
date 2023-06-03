using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MapToolSystem.DAL;
using MapToolSystem.Entities;
using MapToolSystem.BLL;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicationMap.Pages
{
    public class EditServerInfoModel : PageModel
    {
        private readonly MapToolContext dbContext;
        [BindProperty]
        public Server_Info editServerInfoModel { get; set; }
        public User_Backlog_Info user_Backlog_Info { get; set; }
        public User_Backlog_InfoService _user_Backlog_InfoService { get; set; }
        public EditServerInfoModel(MapToolContext dbContext, User_Backlog_InfoService user_Backlog_InfoService)
        {
            this.dbContext = dbContext;
            _user_Backlog_InfoService = user_Backlog_InfoService;
        }
 
        public void OnGet(int id)
        {
            var serverInfo = dbContext.Server_Infos.Find(id);

            if (serverInfo != null)
            {
                editServerInfoModel = new Server_Info()
                {
                    Server_ID = serverInfo.Server_ID,
                    Server_Name = serverInfo.Server_Name,
                    Serial_Number = serverInfo.Serial_Number,
                    IP_Address = serverInfo.IP_Address,
                    Support_Model = serverInfo.Support_Model,
                    OS_Name = serverInfo.OS_Name,
                    Maintenance_Window = serverInfo.Maintenance_Window,
                    Deployment_Type = serverInfo.Deployment_Type,
                    Support_Status = serverInfo.Support_Status,
                    Server_Location = serverInfo.Server_Location,
                    DataCenter = serverInfo.DataCenter,
                    Manufacturer = serverInfo.Manufacturer,
                    Model = serverInfo.Model,
                    Server_Type = serverInfo.Server_Type,
                    Server_Env = serverInfo.Server_Env,
                    Service_Owner = serverInfo.Service_Owner,
                    App_Instance_Name = serverInfo.App_Instance_Name
                };       
            }
        }

        public void OnPost()
        {
            if (editServerInfoModel != null)
            {
                var existingServerInfo = dbContext.Server_Infos.Find(editServerInfoModel.Server_ID);



                if (existingServerInfo != null)
                {
                    existingServerInfo.Server_Name = editServerInfoModel.Server_Name;
                    existingServerInfo.Serial_Number = editServerInfoModel.Serial_Number;
                    existingServerInfo.IP_Address = editServerInfoModel.IP_Address;
                    existingServerInfo.Support_Model = editServerInfoModel.Support_Model;
                    existingServerInfo.OS_Name = editServerInfoModel.OS_Name;
                    existingServerInfo.Maintenance_Window = editServerInfoModel.Maintenance_Window;
                    existingServerInfo.Deployment_Type = editServerInfoModel.Deployment_Type;
                    existingServerInfo.Support_Status = editServerInfoModel.Support_Status;
                    existingServerInfo.Server_Location = editServerInfoModel.Server_Location;
                    existingServerInfo.DataCenter = editServerInfoModel.DataCenter;
                    existingServerInfo.Manufacturer = editServerInfoModel.Manufacturer;
                    existingServerInfo.Model = editServerInfoModel.Model;
                    existingServerInfo.Server_Type = editServerInfoModel.Server_Type;
                    existingServerInfo.Server_Env = editServerInfoModel.Server_Env;
                    existingServerInfo.Service_Owner = editServerInfoModel.Service_Owner;
                    existingServerInfo.App_Instance_Name = editServerInfoModel.App_Instance_Name;

                    user_Backlog_Info = _user_Backlog_InfoService.GetLastUserFromBacklog_List();
                    user_Backlog_Info.ActionDone = $"Edit server info - {existingServerInfo.Server_Name}";
                    dbContext.UserBacklogs.Add(user_Backlog_Info);
                    dbContext.SaveChanges();

                    ViewData["Message"] = "Server Info Record Updated ";
                }
            }
        }

        public IActionResult OnPostDelete()
        {
            var existingServerInfo = dbContext.Server_Infos.Find(editServerInfoModel.Server_ID);

            if (existingServerInfo != null)
            {
                dbContext.Server_Infos.Remove(existingServerInfo);
                user_Backlog_Info = _user_Backlog_InfoService.GetLastUserFromBacklog_List();
                user_Backlog_Info.ActionDone = $"Deleted server info - {existingServerInfo.Server_Name}";
                dbContext.UserBacklogs.Add(user_Backlog_Info);
                dbContext.SaveChanges();
                ViewData["Message"] = "Record Deleted";
                return RedirectToPage("/ServerInfoPage");
            }
            return Page();
        }
        public IActionResult OnPostRetiredServer()
        {
            Retired_Server_InfoServices retiredServerInfoServer = new Retired_Server_InfoServices();
            Retired_Server_Info retiredServerInfo;

            var existingServerInfo = dbContext.Server_Infos.Find(editServerInfoModel.Server_ID);

            if (existingServerInfo != null)
            {
                dbContext.Server_Infos.Remove(existingServerInfo);
                retiredServerInfo = retiredServerInfoServer.MapRetired_Server_Info(existingServerInfo);
                retiredServerInfo.Retirement_Date = DateTime.Now;
                user_Backlog_Info = _user_Backlog_InfoService.GetLastUserFromBacklog_List();
                user_Backlog_Info.ActionDone = $"Move server info to Retired Server - {existingServerInfo.Server_Name}";
                dbContext.UserBacklogs.Add(user_Backlog_Info);
                dbContext.Retired_Server_Info.Add(retiredServerInfo);
                dbContext.SaveChanges();


                ViewData["Message"] = "Server Retired";
            }

            return Page();
        }

    }
}
