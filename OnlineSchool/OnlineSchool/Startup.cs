using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineSchool.Startup))]
namespace OnlineSchool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
