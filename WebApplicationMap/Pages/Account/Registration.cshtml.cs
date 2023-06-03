using MapToolSystem.DAL;
using MapToolSystem.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationMap.Pages.Account
{
    public class RegistrationModel : PageModel
    {
        [BindProperty]
        public User_Permition user_Permition { get; set; }
        public User_Backlog_Info user_Backlog_Info { get; set; }

        private readonly MapToolContext dbContext;
        public RegistrationModel(MapToolContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost()
        {
            if (user_Permition.UserName != null && user_Permition.Password != null)
            {
                user_Permition.Password = BCrypt.Net.BCrypt.HashPassword(user_Permition.Password);
                user_Permition.Permission_Level = "user";

                dbContext.UserPermitions.Add(user_Permition);
                await dbContext.SaveChangesAsync();

                ViewData["Message"] = "Successfully registered";

                return Page();
                //return RedirectToPage("Login");
            }
            return Page();
        }
    }
}
