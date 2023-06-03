using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MapToolSystem.DAL;
using MapToolSystem.Entities;
using MapToolSystem.BLL;

namespace WebApplicationMap.Pages
{
    public class EditAppInfoModel : PageModel
    {
        private readonly MapToolContext dbContext;
        [BindProperty]
        public App_Info editAppInfoModel { get; set; }
        public User_Backlog_Info user_Backlog_Info { get; set; }
        public User_Backlog_InfoService _user_Backlog_InfoService { get; set; }
        public EditAppInfoModel(MapToolContext dbContext, User_Backlog_InfoService user_Backlog_InfoService)
        {
            this.dbContext = dbContext;
            this._user_Backlog_InfoService = user_Backlog_InfoService;
        }
        public void OnGet(int id)
        {
            var appInfo = dbContext.App_Infos.Find(id);

            if (appInfo != null)
            {
                editAppInfoModel = new App_Info()
                {
                    App_ID = appInfo.App_ID,
                    Primary_ServiceOwner = appInfo.Primary_ServiceOwner,
                    App_Version = appInfo.App_Version,
                    Instance_Name = appInfo.Instance_Name,
                    AD_Integrated = appInfo.AD_Integrated,
                    Citrix_hosted = appInfo.Citrix_hosted,
                    HyperDrive_Ready = appInfo.HyperDrive_Ready,
                    ISS_Required = appInfo.ISS_Required,
                    DotNet = appInfo.DotNet,
                    SSL_Certificate = appInfo.SSL_Certificate,
                    AV_Exclusions = appInfo.AV_Exclusions,
                    App_Storage = appInfo.App_Storage,
                    IAM_Integrated = appInfo.IAM_Integrated
                };
            }
        }
        public void OnPost()
        {
            if (editAppInfoModel != null)
            {
                var existingAppInfo = dbContext.App_Infos.Find(editAppInfoModel.App_ID);

                if (existingAppInfo != null)
                {
                    existingAppInfo.App_ID = editAppInfoModel.App_ID;
                    existingAppInfo.Primary_ServiceOwner = editAppInfoModel.Primary_ServiceOwner;
                    existingAppInfo.App_Version = editAppInfoModel.App_Version;
                    existingAppInfo.Instance_Name = editAppInfoModel.Instance_Name;
                    existingAppInfo.AD_Integrated = editAppInfoModel.AD_Integrated;
                    existingAppInfo.Citrix_hosted = editAppInfoModel.Citrix_hosted;
                    existingAppInfo.HyperDrive_Ready = editAppInfoModel.HyperDrive_Ready;
                    existingAppInfo.ISS_Required = editAppInfoModel.ISS_Required;
                    existingAppInfo.DotNet = editAppInfoModel.DotNet;
                    existingAppInfo.SSL_Certificate = editAppInfoModel.SSL_Certificate;
                    existingAppInfo.AV_Exclusions = editAppInfoModel.AV_Exclusions;
                    existingAppInfo.App_Storage = editAppInfoModel.App_Storage;
                    existingAppInfo.IAM_Integrated = editAppInfoModel.IAM_Integrated;

                    user_Backlog_Info = _user_Backlog_InfoService.GetLastUserFromBacklog_List();
                    user_Backlog_Info.ActionDone = $"Edit app info - {existingAppInfo.Instance_Name}";
                    dbContext.UserBacklogs.Add(user_Backlog_Info);
                    dbContext.SaveChanges();

                    ViewData["Message"] = "App info updated successfully";
                }
            }
        }

        public IActionResult OnPostDelete()
        {
            var existingAppInfo = dbContext.App_Infos.Find(editAppInfoModel.App_ID);

            if (existingAppInfo != null)
            {
                dbContext.App_Infos.Remove(existingAppInfo);
                user_Backlog_Info = _user_Backlog_InfoService.GetLastUserFromBacklog_List();
                user_Backlog_Info.ActionDone = $"Deleted app info - {existingAppInfo.Instance_Name}";
                dbContext.UserBacklogs.Add(user_Backlog_Info);
                dbContext.SaveChanges();
                return RedirectToPage("/AppInfoPage");
            }
            return Page();
        }
    }
}
