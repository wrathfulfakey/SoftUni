namespace IRunes
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using SIS.HTTP;
    using SIS.MvcFramework;

    using IRunes.Services;

    public class StartUp : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IAlbumsService, AlbumsService>();
            serviceCollection.Add<ITracksService, TracksService>();
        }

        public void Configure(IList<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}
