using MapToolSystem.DAL;
using MapToolSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapToolSystem.BLL
{
    public class User_Backlog_InfoService
    {
        private readonly MapToolContext _context;
        internal User_Backlog_InfoService(MapToolContext regcontext)
        {
            _context = regcontext;
        }

        public List<User_Backlog_Info> UserBacklog_List()
        {
            IEnumerable<User_Backlog_Info> info = _context.UserBacklogs
                                           .OrderByDescending(x => x.DateAndTime);
            return info.ToList();
        }
        public User_Backlog_Info GetLastUserFromBacklog_List()
        {
            User_Backlog_Info info = _context.UserBacklogs.OrderBy(x=>x.BacklogId).Last();
            User_Backlog_Info user_Backlog_Info = new User_Backlog_Info{
                UserId = info.UserId,
                UserName = info.UserName,
                AssignSaName = info.AssignSaName,
                PermissionLevel = info.PermissionLevel,
                ActiveStatus = info.ActiveStatus,
                DateAndTime = DateTime.Now,
            };

            return user_Backlog_Info;
        }
    }
}
