using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(tune.Startup))]
namespace tune
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
