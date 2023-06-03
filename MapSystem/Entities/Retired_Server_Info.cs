using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapToolSystem.Entities
{
    [Table("Retired_Server_Info")]
    public class Retired_Server_Info
    {

        [Key]
        public int Server_ID { get; set; }


        public string? Server_Name { get; set; }

        public string? Serial_Number { get; set; }

        public string? IP_Address { get; set; }

        public string? Support_Model { get; set; }

        public string? OS_Name { get; set; }

        public string? Build_Date { get; set; }

        public string? Maintenance_Window { get; set; }

        public string? Deployment_Type { get; set; }

        public string? Support_Status { get; set; }

        public string? Server_Location { get; set; }

        public string? DataCenter { get; set; }

        public string? Manufacturer { get; set; }

        public string? Model { get; set; }

        public string? Server_Type { get; set; }

        public string? DBType { get; set; }

        public string? NoOfCPUs { get; set; }

        public string? CPUCores { get; set; }

        public string? CPUSpeeds { get; set; }

        public string? RAM { get; set; }
        public string? Primary_App { get; set; }
        public string? Secondary_App { get; set; }
        public string? Other_App { get; set; }

        public string? App_Type { get; set; }

        public string? App_Env { get; set; }

        public string? Server_Env { get; set; }

        public string? Site { get; set; }

        public string? DMZ { get; set; }

        public string? Service_Owner { get; set; }
        public string? Comments { get; set; }

        public string? CreatedBy { get; set; }

        public string? CreatedDate { get; set; }

        public string? EditedBy { get; set; }

        public string? EditedDate { get; set; }
        public string? Last_Patched { get; set; }
        public string? App_Instance_Name { get; set; }

        public string? Patching_Source { get; set; }

        public string? Frequency { get; set; }

        public string? Vendor_approved { get; set; }

        public string? Patching_Team { get; set; }

        public string? Preferred_Schedule_Time { get; set; }

        public string? Patching_Analyst { get; set; }

        public string? WorkGroup { get; set; }
        public string? Patching_Instruction { get; set; }

        public string? Zabbix_Agent { get; set; }

        public string? Zone { get; set; }

        public string? IsAutomationAllowed { get; set; }

        public string? SysAdmin_Access { get; set; }

        public DateTime? Retirement_Date { get; set; }
    }
}
