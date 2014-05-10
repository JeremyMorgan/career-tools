using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CareerTools.Startup))]
namespace CareerTools
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
