using MapToolSystem.BLL;
using MapToolSystem.DAL;
using MapToolSystem.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;


namespace WebApplicationMap.Pages.Account
{
    public class LogOutModel : PageModel
    {
        private readonly MapToolContext _dbContext;
        public User_Backlog_Info user_Backlog_Info { get; set; }
        public User_Backlog_InfoService _user_Backlog_InfoService { get; set; }
        public LogOutModel(MapToolContext dbContext, User_Backlog_InfoService user_Backlog_InfoService)
        {
            _dbContext = dbContext;
            _user_Backlog_InfoService = user_Backlog_InfoService;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            user_Backlog_Info = _user_Backlog_InfoService.GetLastUserFromBacklog_List();
            user_Backlog_Info.ActionDone = $"Log out";
            _dbContext.UserBacklogs.Add(user_Backlog_Info);
            _dbContext.SaveChanges();
            return RedirectToPage("/Account/Login");
        }
        
    }
}
