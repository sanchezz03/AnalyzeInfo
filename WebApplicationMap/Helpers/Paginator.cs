using MapToolSystem.Entities;

namespace WebApplicationMap.Helpers
{
    public class Paginator<T>:List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public Paginator()
        {
            
        }
        public Paginator(List<T> items, int count, int pageIndex,
            int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count /(double)pageSize);
            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static Paginator<T> Create(List<T> source,
            int pageIndex, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new Paginator<T>(items, count, pageIndex, pageSize);
        }

        public static explicit operator Paginator<T>(List<App_Info> v)
        {
            throw new NotImplementedException();
        }
        /*public static Paginator<T> Create(List<T> source, int pageIndex, int pageSize)
{
   var count = source.Count;
   var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
   return new Paginator<T>(items, count, pageIndex, pageSize);
}*/
    }
}
