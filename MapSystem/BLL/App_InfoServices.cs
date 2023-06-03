using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MapToolSystem.DAL;
using MapToolSystem.Entities;

namespace MapToolSystem.BLL
{
    public class App_InfoServices
    {
        private readonly MapToolContext _context;
        internal App_InfoServices(MapToolContext regcontext)
        {
            _context = regcontext;
        }
        public App_InfoServices()
        {
        }

        public App_Info MapRetired_App_Info(App_Info app_Info)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Server_Info, Server_Info>());

            var mapper = new Mapper(config);

            App_Info appInfo = mapper.Map<App_Info>(app_Info);
            return appInfo;
        }
        public List<App_Info> GetByPartialValue(string value)
        {
            int id = -1000;
            try
            {
                id = Convert.ToInt32(value);
            }
            catch { }
            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.App_ID == id || x.Primary_ServiceOwner.Contains(value) || x.App_Version.Contains(value) || x.Instance_Name.Contains(value) || x.AD_Integrated.Contains(value) || x.Citrix_hosted.Contains(value) || x.HyperDrive_Ready.Contains(value) || x.ISS_Required.Contains(value) || x.DotNet.Contains(value) || x.SSL_Certificate.Contains(value) || x.AV_Exclusions.Contains(value) || x.App_Storage.Contains(value) || x.IAM_Integrated.Contains(value));

            return info.ToList();
        }
        
        public List<App_Info> GetByPartialAppId(int appId)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.App_ID == appId)
                                .OrderBy(x => x.App_ID);
            return info.ToList();
        }

        public List<App_Info> GetByPartialPrimaryServiceOwner(string primaryServiceOwner)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.Primary_ServiceOwner.Contains(primaryServiceOwner))
                                .OrderBy(x => x.Primary_ServiceOwner);
            return info.ToList();
        }
        public List<App_Info> GetByPartialInstanceName(string partialInstanceName)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.Instance_Name.Contains(partialInstanceName))
                                .OrderBy(x => x.Instance_Name);
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
                                .Where(x => x.Citrix_hosted.Contains( citrixHosted))
                                .OrderBy(x => x.Citrix_hosted);
            return info.ToList();
        }
        public List<App_Info> GetByPartialHyperDriveReady(string _hyperDriveReady)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.HyperDrive_Ready == _hyperDriveReady)
                                .OrderBy(x => x.HyperDrive_Ready);
            return info.ToList();
        }
        public List<App_Info> GetByPartialIssRequired(string _iisRequired)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.ISS_Required == _iisRequired)
                                .OrderBy(x => x.ISS_Required);
            return info.ToList();
        }
        public List<App_Info> GetByPartialDotNet(string _dotNet)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.DotNet == _dotNet)
                                .OrderBy(x => x.DotNet);
            return info.ToList();
        }
        public List<App_Info> GetByPartialSslCertificate(string _sslCertificate)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.SSL_Certificate == _sslCertificate)
                                .OrderBy(x => x.SSL_Certificate);
            return info.ToList();
        }
        public List<App_Info> GetByPartialAvExclusions(string _avExclusions)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.AV_Exclusions == _avExclusions)
                                .OrderBy(x => x.AV_Exclusions);
            return info.ToList();
        }
        public List<App_Info> GetByPartialAppStorage(string _appStorage)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.App_Storage == _appStorage)
                                .OrderBy(x => x.App_Storage);
            return info.ToList();
        }
        public List<App_Info> GetByPartialIAmIntegrated(string _iamIntegrated)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.IAM_Integrated == _iamIntegrated)
                                .OrderBy(x => x.IAM_Integrated);
            return info.ToList();
        }
        public List<App_Info> GetByPartialAppName(string appname)
        {

            IEnumerable<App_Info> info = _context.App_Infos
                                .Where(x => x.App_Name.Contains(appname))
                                .OrderBy(x => x.IAM_Integrated);
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
    }

}
