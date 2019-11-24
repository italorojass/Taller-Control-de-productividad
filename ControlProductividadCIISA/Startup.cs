using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ControlProductividadCIISA.Startup))]
namespace ControlProductividadCIISA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
