using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapToolSystem.DAL;
using MapToolSystem.Entities;

namespace MapToolSystem.BLL
{
    public class IndexServices
    {
        private readonly MapToolContext _context;
        internal IndexServices(MapToolContext regcontext)
        {
            _context = regcontext;
        }
        public List<App_Info> GetByPartialPrimaryServiceOwner(string primaryServiceOwner)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.Primary_ServiceOwner.Contains(primaryServiceOwner))
                                .OrderBy(x => x.Primary_ServiceOwner);
            return info.ToList();
        }
        public List<App_Info>GetByPartialInstanceName(string instanceName)
        {
            IEnumerable<App_Info> info = _context.App_Infos
                .Where(x=> x.Instance_Name.Contains(instanceName))
                .OrderBy (x => x.Instance_Name);
            return info.ToList();
        }
        public List<App_Info> GetByPartialAppName(string appname)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.App_Name.Contains(appname))
                                .OrderBy(x => x.IAM_Integrated);
            return info.ToList();
        }

        public List<App_Info> GetByPartialAppVersion(string appVersion)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.App_Version.Contains(appVersion))
                                .OrderBy(x => x.App_Version);
            return info.ToList();
        }
        public List<App_Info> GetByPartialAdIntegrated(string adIntegrated)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.AD_Integrated.Contains(adIntegrated))
                                .OrderBy(x => x.AD_Integrated);
            return info.ToList();
        }
        public List<App_Info> GetByPartialCitrixHosted(string citrixHosted)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.Citrix_hosted.Contains(citrixHosted))
                                .OrderBy(x => x.Citrix_hosted);
            return info.ToList();
        }
        public List<App_Info> GetByServerId(int appId)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.App_ID == appId)
                                .OrderBy(x => x.App_ID);
            return info.ToList();
        }

        public List<App_Info> GetAppInfo()
        {

            return _context.App_Infos.ToList();
        }
        public App_Info GetById(int id)
        {
            return _context.App_Infos.FirstOrDefault(x => x.App_ID == id);
        }
        public Server_Info ServerInfo_GetById(int serverId)
        {
            Server_Info info = _context.Server_Infos
                              .Where(x => x.Server_ID == serverId
                              )
                              .FirstOrDefault();
            return info;
        }

        public List<Server_Info> ServerInfo_List()
        {
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
