using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MoarSportz.Models;
using Owin;
using System.Linq;

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
