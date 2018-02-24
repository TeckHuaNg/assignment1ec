using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(assignment1comp2007.Startup))]
namespace assignment1comp2007
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
