using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FamousHumidors.Startup))]
namespace FamousHumidors
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
