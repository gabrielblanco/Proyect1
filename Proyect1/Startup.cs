using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proyect1.Startup))]
namespace Proyect1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
