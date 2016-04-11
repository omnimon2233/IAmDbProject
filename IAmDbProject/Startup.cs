using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IAmDbProject.Startup))]
namespace IAmDbProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
