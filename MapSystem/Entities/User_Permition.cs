using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapToolSystem.Entities
{
    public class User_Permition
    {
        public int UserID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Assign_SA_Name { get; set; }
        public string? Permission_Level { get; set; }
        public string? ActiveStatus { get; set; }

    }
}
