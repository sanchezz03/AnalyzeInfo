using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MapToolSystem.DAL;
using MapToolSystem.Entities;

namespace MapToolSystem.BLL
{
    public class Server_InfoServices
    {
        private readonly MapToolContext _context;
        internal Server_InfoServices(MapToolContext regcontext)
        {
            _context = regcontext;
        }

        public Server_InfoServices()
        {
        }

        public Server_Info MapRetired_Server_Info(Server_Info server_Info)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Server_Info, Server_Info>());

            var mapper = new Mapper(config);

            Server_Info serverInfo = mapper.Map<Server_Info>(server_Info);
            return serverInfo;
        }
        public List<Server_Info> GetByPartialValue(string value)
        {
            int id = -1000;
            try
            {
                id = Convert.ToInt32(value);
            }
            catch { }
            IEnumerable<Server_Info> info = _context.Server_Infos
                                .Where(x => x.Server_ID == id || x.Server_Name.Contains(value) || x.Serial_Number.Contains(value) || x.IP_Address.Contains(value) || x.Support_Model.Contains(value) || x.OS_Name.Contains(value) || x.Build_Date.Contains(value) || x.Maintenance_Window.Contains(value) || x.Deployment_Type.Contains(value) || x.Support_Status.Contains(value) || x.Server_Location.Contains(value) || x.DataCenter.Contains(value) || x.Manufacturer.Contains(value) || x.Model.Contains(value) || x.Server_Type.Contains(value) || x.DBType.Contains(value) || x.NoOfCPUs.Contains(value) || x.CPUCores.Contains(value) || x.CPUSpeeds.Contains(value) || x.RAM.Contains(value) || x.Primary_App.Contains(value) || x.Secondary_App.Contains(value) || x.Other_App.Contains(value) || x.App_Type.Contains(value) || x.App_Env.Contains(value) || x.Server_Env.Contains(value) || x.Site.Contains(value) || x.DMZ.Contains(value) || x.Service_Owner.Contains(value) || x.Comments.Contains(value) || x.CreatedBy.Contains(value) || x.CreatedDate.Contains(value) || x.EditedBy.Contains(value) || x.EditedDate.Contains(value) || x.Last_Patched.Contains(value) || x.App_Instance_Name.Contains(value) || x.Patching_Source.Contains(value) || x.Frequency.Contains(value) || x.Vendor_approved.Contains(value) || x.Patching_Team.Contains(value) || x.Preferred_Schedule_Time.Contains(value) || x.Patching_Analyst.Contains(value) || x.WorkGroup.Contains(value) || x.Patching_Instruction.Contains(value) || x.Zabbix_Agent.Contains(value) || x.Zone.Contains(value) || x.IsAutomationAllowed.Contains(value) || x.SysAdmin_Access.Contains(value));

            return info.ToList();
        }
        public Server_Info ServerInfo_GetById(int serverId)
        {
            Server_Info info = _context.Server_Infos
                              .Where(x => x.Server_ID == serverId
                              )
                              .FirstOrDefault();
            return info;
        }

        public List<Server_Info> ServerInfo_List() {
            IEnumerable<Server_Info> info = _context.Server_Infos
                                           .OrderBy(x => x.Server_Name);
            return info.ToList();
        }
        public List<Server_Info> GetByPartialServerName(string partialServerName)
        {

            IEnumerable<Server_Info> info = _context.Server_Infos
                                .Where(x => x.Server_Name.Contains(partialServerName))
                                .OrderBy(x => x.Server_Name);
            return info.ToList();
        }

        public List<Server_Info> GetByPartialSerialNumber(string partialSerialNumber)
        {

            IEnumerable<Server_Info> info = _context.Server_Infos
                                .Where(x => x.Serial_Number.Contains(partialSerialNumber))
                                .OrderBy(x => x.Serial_Number);
            return info.ToList();
        }

        public List<Server_Info> GetByPartialServerLocation(string partialServerLocation)
        {

            IEnumerable<Server_Info> info = _context.Server_Infos
                                .Where(x => x.Server_Location.Contains(partialServerLocation))
                                .OrderBy(x => x.Server_Location);
            return info.ToList();
        }

        public List<Server_Info> GetByPartialMaintanenceWindow(string partialMaintanenceWindow)
        {

            IEnumerable<Server_Info> info = _context.Server_Infos
                                .Where(x => x.Maintenance_Window.Contains(partialMaintanenceWindow))
                                .OrderBy(x => x.Maintenance_Window);
            return info.ToList();
        }

        public List<Server_Info> GetByPartialServiceOwner(string partialServiceOwner)
        {

            IEnumerable<Server_Info> info = _context.Server_Infos
                                .Where(x => x.Service_Owner.Contains(partialServiceOwner))
                                .OrderBy(x => x.Service_Owner);
            return info.ToList();
        }

        public List<Server_Info> GetByPartialAppInstanceName(string partialAppInstanceName)
        {

            IEnumerable<Server_Info> info = _context.Server_Infos
                                .Where(x => x.App_Instance_Name.Contains(partialAppInstanceName))
                                .OrderBy(x => x.App_Instance_Name);
            return info.ToList();
        }

        public List<Server_Info> GetByPartialDataCenter(string partialDataCenter)
        {

            IEnumerable<Server_Info> info = _context.Server_Infos
                                .Where(x => x.DataCenter.Contains(partialDataCenter))
                                .OrderBy(x => x.DataCenter);
            return info.ToList();
        }

        public List<Server_Info> GetByPartialIpAddress(string partialIpAddress)
        {

            IEnumerable<Server_Info> info = _context.Server_Infos
                                .Where(x => x.IP_Address.Contains(partialIpAddress))
                                .OrderBy(x => x.IP_Address);
            return info.ToList();
        }

        public List<Server_Info> GetByPartialServerId(string partialServerId)
        {
            if (!int.TryParse(partialServerId, out int serverId))
            {
                return new List<Server_Info>();
            }

            IEnumerable<Server_Info> info = _context.Server_Infos
                .Where(x => x.Server_ID == serverId)
                .OrderBy(x => x.Server_ID);

            return info.ToList();
        }
    }
}
