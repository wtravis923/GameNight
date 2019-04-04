using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameNight.Startup))]
namespace GameNight
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
