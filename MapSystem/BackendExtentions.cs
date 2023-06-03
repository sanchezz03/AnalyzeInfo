
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MapToolSystem.DAL;
using MapToolSystem.BLL;
#endregion

namespace MapToolSystem
{
    public static class BackendExtentions
    {
        public static void MapToolBackendDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<MapToolContext>(options);

            services.AddTransient<App_InfoServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<MapToolContext>();

                return new App_InfoServices(context);
            });
             services.AddTransient<Server_InfoServices>((serviceProvider) =>
             {
                 var context = serviceProvider.GetService<MapToolContext>();

                 return new Server_InfoServices(context);
             });
            services.AddTransient<Retired_Server_InfoServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<MapToolContext>();

                return new Retired_Server_InfoServices(context);
            });
            services.AddTransient<User_PermitionService>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<MapToolContext>();

                return new User_PermitionService(context);
            });
            services.AddTransient<User_Backlog_InfoService>((serviceProvider) =>
            {
                var context = serviceProvider.GetService<MapToolContext>();

                return new User_Backlog_InfoService(context);
            });

        }
    }
}
