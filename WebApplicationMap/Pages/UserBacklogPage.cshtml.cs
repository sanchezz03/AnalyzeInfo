using MapToolSystem.BLL;
using MapToolSystem.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplicationMap.Helpers;

namespace WebApplicationMap.Pages
{
    [Authorize]
    public class UserBacklogPageModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly User_Backlog_InfoService _userBacklogInfoServices;
        [BindProperty]
        public Paginator<User_Backlog_Info> UserBacklogInfosList { get; set; }
        public UserBacklogPageModel(ILogger<IndexModel> logger, User_Backlog_InfoService userBacklogInfoServices)
        {
            _logger = logger;
            _userBacklogInfoServices = userBacklogInfoServices;
        }
        public void OnGet(int?pageIndex)
        {
            int pageSize = 5;

            UserBacklogInfosList = Paginator<User_Backlog_Info>.Create(_userBacklogInfoServices.UserBacklog_List(),
                pageIndex ?? 1, pageSize);
        }
    }
}
