using MapToolSystem.Entities;

namespace MapToolSystem.BLL
{
    internal class Paginator<T>
    {
        private List<Server_Info> filteredServerInfos;
        private int pageIndex;
        private int pageSize;

        public Paginator()
        {
            
        }
        public Paginator(List<Server_Info> filteredServerInfos, int pageIndex, int pageSize)
        {
            this.filteredServerInfos = filteredServerInfos;
            this.pageIndex = pageIndex;
            this.pageSize = pageSize;
        }

        internal static List<Server_Info> Create(List<Server_Info> filteredServerInfos, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}