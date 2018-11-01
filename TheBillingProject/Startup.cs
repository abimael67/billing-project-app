using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheBillingProject.Startup))]
namespace TheBillingProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
