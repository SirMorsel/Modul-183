using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TwoFactorAutication.Startup))]
namespace TwoFactorAutication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
