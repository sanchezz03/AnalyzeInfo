using System;
using System.Collections.Generic;

namespace MapToolSystem.Entities
{
    public partial class User_Backlog_Info
    {
        public int BacklogId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? AssignSaName { get; set; }
        public string? PermissionLevel { get; set; }
        public string? ActiveStatus { get; set; }
        public DateTime? DateAndTime { get; set; }
        public string? ActionDone { get; set; }
    }
}
