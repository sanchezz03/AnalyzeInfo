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
    public class LoginModel : PageModel
    {
        [BindProperty]
        public User_Permition user_Permition { get; set; }
        public User_Backlog_Info user_Backlog_Info { get; set; }

        private readonly MapToolContext _dbContext;
        public LoginModel(MapToolContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (user_Permition.UserName!=null&&user_Permition.Password!=null)
            {
                User_PermitionService user_PermitionService = new User_PermitionService(_dbContext);

                user_Permition = await user_PermitionService.UserPermition_GetByNameAndPassword(user_Permition.UserName, user_Permition.Password);

                if (user_Permition != null)
                {
                    Authenticate(user_Permition);

                    user_Backlog_Info = new User_Backlog_Info
                    {
                        UserId = user_Permition.UserID,
                        UserName = user_Permition.UserName,
                        AssignSaName = user_Permition.Assign_SA_Name,
                        PermissionLevel = user_Permition.Permission_Level,
                        ActiveStatus = user_Permition.ActiveStatus,
                        DateAndTime = DateTime.Now,
                        ActionDone = "Log in"
                    };

                    _dbContext.UserBacklogs.Add(user_Backlog_Info);
                    await _dbContext.SaveChangesAsync();
              
                    return RedirectToPage("/Index");
                }
                else
                    ViewData["Message"] = "You entered the wrong password or login";
            }
   
            return Page();
        }

        private async Task Authenticate(User_Permition user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Permission_Level)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "MyCookieAuth", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
