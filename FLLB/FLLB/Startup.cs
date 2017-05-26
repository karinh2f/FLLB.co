using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FLLB.Startup))]
namespace FLLB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
