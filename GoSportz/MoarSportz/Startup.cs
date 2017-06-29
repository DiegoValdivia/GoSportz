using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoarSportz.Startup))]
namespace MoarSportz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
