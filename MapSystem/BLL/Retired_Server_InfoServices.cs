using AutoMapper;
using MapToolSystem.DAL;
using MapToolSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapToolSystem.BLL
{
    public class Retired_Server_InfoServices
    {
        private readonly MapToolContext _context;

        public Retired_Server_InfoServices()
        {
        }

        public Retired_Server_InfoServices(MapToolContext regcontext)
        {
            _context = regcontext;
        }
        public Retired_Server_Info MapRetired_Server_Info(Server_Info server_Info)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Server_Info, Retired_Server_Info>());

            var mapper = new Mapper(config);

            Retired_Server_Info retiredServerInfo = mapper.Map<Retired_Server_Info>(server_Info);
            return retiredServerInfo;
        }
        public Retired_Server_Info RetiredServerInfoGetById(int Server_ID)
        {
            Retired_Server_Info info = _context.Retired_Server_Info
                              .Where(x => x.Server_ID == Server_ID)
                              .FirstOrDefault();
            return info;
        }
        public List<Retired_Server_Info> RetiredServerInfo_List()
        {
            IEnumerable<Retired_Server_Info> info = _context.Retired_Server_Info.ToList();
            return info.ToList();
        }
    }
}
